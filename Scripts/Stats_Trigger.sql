USE [FinanceManagerDb]

CREATE TRIGGER [dbo].[Stats_Trigger] ON [FinanceManagerDb].[dbo].[Transaction_Acc]
FOR INSERT, DELETE 
NOT FOR REPLICATION 
AS
 
BEGIN
    IF EXISTS ( SELECT 0 FROM Inserted )
    BEGIN
        IF EXISTS (SELECT * FROM [FinanceManagerDb].[dbo].[Stats] S,
                            (SELECT [transaction_Date],[account_id] from Inserted ) Tr 
                             WHERE Month(S.[stats_date]) = Month(Tr.[transaction_Date]) AND 
                                    Year(S.[stats_date]) = Year(Tr.[transaction_Date]) AND 
                                      Tr.[account_id]=S.[account_id] AND S.[types_id] = (SELECT [types_id] FROM [FinanceManagerDb].[dbo].[Types]  WHERE [types_name] = 'Month') )
        BEGIN
            UPDATE S
            SET incomes = (case when (SELECT [types_name] FROM [FinanceManagerDb].[dbo].[Types] 
                                                WHERE [types_id] = I.[types_id]) = 'Income' then I.[transaction_price] + S.[incomes] else S.[incomes] 
                          end) ,
                expences = (case when (SELECT [types_name] FROM [FinanceManagerDb].[dbo].[Types] 
                                                WHERE [types_id] = I.[types_id]) = 'Expences' then I.[transaction_price] + S.[expences] else S.[expences] 
                          end) ,
                time_stamp = getdate() 
            FROM [FinanceManagerDb].[dbo].[Stats] S,
                inserted I
			WHERE Month(S.[stats_date]) = Month(I.[transaction_Date]) AND 
                                    Year(S.[stats_date]) = Year(I.[transaction_Date]) AND 
                                      I.[account_id]=S.[account_id] AND S.[types_id] = (SELECT [types_id] FROM [FinanceManagerDb].[dbo].[Types]  WHERE [types_name] = 'Month');
			UPDATE A
			SET A.account_balance = (case when (SELECT [types_name] FROM [FinanceManagerDb].[dbo].[Types] 
                                                WHERE [types_id] = I.[types_id]) = 'Income' then A.[account_balance] + I.[transaction_price] else A.[account_balance] - I.[transaction_price] 
									end) 
			FROM  [FinanceManagerDb].[dbo].[Account] A,
				inserted I
			WHERE A.[account_id] = I.[account_id];
        END
        ELSE
        BEGIN
          INSERT INTO [FinanceManagerDb].[dbo].[Stats]
            SELECT
                DATETIMEFROMPARTS(YEAR(I.[transaction_Date]),MONTH(I.[transaction_Date]),1,0,0,0,0) stats_date
                ,(SELECT [types_id] FROM [FinanceManagerDb].[dbo].[Types] WHERE [types_name] = 'Month') types_id
                ,I.[account_id] account_id
                ,case when (SELECT [types_name] FROM [FinanceManagerDb].[dbo].[Types] 
                                                WHERE [types_id] = I.[types_id]) = 'Income' then I.[transaction_price] else 0  
                 end incomes
                ,case when (SELECT [types_name] FROM [FinanceManagerDb].[dbo].[Types] 
                                                WHERE [types_id] = I.[types_id]) = 'Expences' then I.[transaction_price] else 0  
                 end expences
                , getdate() time_stamp
            FROM inserted I;
		  UPDATE A  
			SET A.account_balance = (case when (SELECT [types_name] FROM [FinanceManagerDb].[dbo].[Types] 
                                                WHERE [types_id] = I.[types_id]) = 'Income' then A.[account_balance] + I.[transaction_price] else A.[account_balance] - I.[transaction_price] 
									end) 
		  FROM  [FinanceManagerDb].[dbo].[Account] A,
				inserted I
		   WHERE A.[account_id] = I.[account_id];
        END

        IF EXISTS (SELECT * FROM [FinanceManagerDb].[dbo].[Stats] S,
                            (SELECT [transaction_Date],[account_id] from Inserted ) Tr 
                             WHERE Year(S.[stats_date]) = Year(Tr.[transaction_Date]) AND 
                                      Tr.[account_id]=S.[account_id] AND S.[types_id] = (SELECT [types_id] FROM [FinanceManagerDb].[dbo].[Types]  WHERE [types_name] = 'Year') )
        BEGIN
            UPDATE S
            SET incomes = (case when (SELECT [types_name] FROM [FinanceManagerDb].[dbo].[Types] 
                                                WHERE [types_id] = I.[types_id]) = 'Income' then I.[transaction_price] + S.[incomes] else S.[incomes] 
                            end) ,
                expences = (case when (SELECT [types_name] FROM [FinanceManagerDb].[dbo].[Types] 
                                                WHERE [types_id] = I.[types_id]) = 'Expences' then I.[transaction_price] + S.[expences] else S.[expences] 
                            end) ,
                time_stamp = getdate() 
            FROM [FinanceManagerDb].[dbo].[Stats] S,
                inserted I
			WHERE Year(S.[stats_date]) = Year(I.[transaction_Date]) AND 
                                      I.[account_id]=S.[account_id] AND S.[types_id] = (SELECT [types_id] FROM [FinanceManagerDb].[dbo].[Types]  WHERE [types_name] = 'Year');
        END
        ELSE
        BEGIN
            INSERT INTO [FinanceManagerDb].[dbo].[Stats]
            SELECT
                DATETIMEFROMPARTS(YEAR(I.[transaction_Date]),1,1,0,0,0,0) stats_date
                ,(SELECT [types_id] FROM [FinanceManagerDb].[dbo].[Types] WHERE [types_name] = 'Year') types_id
                ,I.[account_id] account_id
                ,case when (SELECT [types_name] FROM [FinanceManagerDb].[dbo].[Types] 
                                                WHERE [types_id] = I.[types_id]) = 'Income' then I.[transaction_price] else 0  
                    end incomes
                ,case when (SELECT [types_name] FROM [FinanceManagerDb].[dbo].[Types] 
                                                WHERE [types_id] = I.[types_id]) = 'Expences' then I.[transaction_price] else 0  
                    end expences
                , getdate() time_stamp
            FROM inserted I
        END
    END
    else 
    BEGIN 
        IF EXISTS (SELECT * FROM [FinanceManagerDb].[dbo].[Stats] S,
                            (SELECT [transaction_Date],[account_id] from Deleted ) Tr 
                             WHERE Month(S.[stats_date]) = Month(Tr.[transaction_Date]) AND 
                                    Year(S.[stats_date]) = Year(Tr.[transaction_Date]) AND 
                                      Tr.[account_id]=S.[account_id] AND S.[types_id] = (SELECT [types_id] FROM [FinanceManagerDb].[dbo].[Types]  WHERE [types_name] = 'Month' ) )
        BEGIN
            UPDATE S
            SET incomes = (case when (SELECT [types_name] FROM [FinanceManagerDb].[dbo].[Types] 
                                                WHERE [types_id] = D.[types_id]) = 'Income' then S.[incomes] - D.[transaction_price]  else S.[incomes] 
                          end) ,
                expences = (case when (SELECT [types_name] FROM [FinanceManagerDb].[dbo].[Types] 
                                                WHERE [types_id] = D.[types_id]) = 'Expences' then S.[expences] - D.[transaction_price] else S.[expences] 
                          end) ,
                time_stamp = getdate() 
            FROM [FinanceManagerDb].[dbo].[Stats] S,
                Deleted D
			WHERE Month(S.[stats_date]) = Month(D.[transaction_Date]) AND 
                                    Year(S.[stats_date]) = Year(D.[transaction_Date]) AND 
                                      D.[account_id]=S.[account_id] AND S.[types_id] = (SELECT [types_id] FROM [FinanceManagerDb].[dbo].[Types]  WHERE [types_name] = 'Month' ) ;
			UPDATE A  
			SET A.account_balance = (case when (SELECT [types_name] FROM [FinanceManagerDb].[dbo].[Types] 
                                                WHERE [types_id] = I.[types_id]) = 'Income' then A.[account_balance] - I.[transaction_price] else A.[account_balance] + I.[transaction_price] 
									end) 
			FROM  [FinanceManagerDb].[dbo].[Account] A,
				inserted I
			WHERE A.[account_id] = I.[account_id];
        END

        IF EXISTS (SELECT * FROM [FinanceManagerDb].[dbo].[Stats] S,
                            (SELECT [transaction_Date],[account_id] from Deleted ) Tr 
                             WHERE Year(S.[stats_date]) = Year(Tr.[transaction_Date]) AND 
                                      Tr.[account_id]=S.[account_id] AND S.[types_id] = (SELECT [types_id] FROM [FinanceManagerDb].[dbo].[Types]  WHERE [types_name] = 'Year'))
        BEGIN
            UPDATE S
            SET incomes = (case when (SELECT [types_name] FROM [FinanceManagerDb].[dbo].[Types] 
                                                WHERE [types_id] = D.[types_id]) = 'Income' then S.[incomes] - D.[transaction_price]  else S.[incomes] 
                            end) ,
                expences = (case when (SELECT [types_name] FROM [FinanceManagerDb].[dbo].[Types] 
                                                WHERE [types_id] = D.[types_id]) = 'Expences' then S.[expences] - D.[transaction_price] else S.[expences] 
                            end) ,
                time_stamp = getdate() 
            FROM [FinanceManagerDb].[dbo].[Stats] S,
                deleted D
			WHERE Year(S.[stats_date]) = Year(D.[transaction_Date]) AND 
                                      D.[account_id]=S.[account_id] AND S.[types_id] = (SELECT [types_id] FROM [FinanceManagerDb].[dbo].[Types]  WHERE [types_name] = 'Year');
        END
       
    END
END