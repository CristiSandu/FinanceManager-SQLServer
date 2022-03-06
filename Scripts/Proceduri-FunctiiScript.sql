-- Get Account Extended Infos
CREATE PROCEDURE GetAccoutsInfos
AS
BEGIN
SET NOCOUNT ON
        SELECT A.[account_id]
        ,A.[account_balance]
        ,A.[types_id]
        ,T.[icon]
        ,A.[bank_id]
        ,B.[bank_name]
        ,A.[account_balance]
        ,A.[account_IBAN]
        ,A.[time_stamp]
        ,A.[account_holder]
    FROM [FinanceManagerDb].[dbo].[Account] A,
        [FinanceManagerDb].[dbo].[Types] T,
        [FinanceManagerDb].[dbo].[Bank] B
    WHERE A.[types_id] = T.[types_id] AND B.[bank_id] = A.[bank_id]
END


-- Get Types by a given table
CREATE PROCEDURE GetTypesByTables
(@Table_name VARCHAR(32))
AS
BEGIN
SET NOCOUNT ON
    SELECT 
     [types_id]
    ,[types_name]
    ,[table_name]
    ,[icon]
FROM [FinanceManagerDb].[dbo].[Types]
WHERE @Table_name = [table_name]
END

-- Transaction combined with category for image 
-- JOIN Transaction Type and Category 
CREATE PROCEDURE GetTransactionForAnAccount
(@account_id INT)
AS
BEGIN
SET NOCOUNT ON
    SELECT T.[transaction_id]
        ,T.[transaction_name]
        ,Ty.[icon] TypeIcon
        ,M.[merchant_name]
        ,C.[category_name]
        ,C.[icon] CategoryIcon
        ,C.[color]
        ,T.[transaction_price]
        ,T.[transaction_Date]
        ,T.[image]
        ,T.[transaction_description]
        ,T.[time_stamp]
    FROM [FinanceManagerDb].[dbo].[Transaction_Acc] T,
        [FinanceManagerDb].[dbo].[Types] Ty,
        [FinanceManagerDb].[dbo].[Category] C,
        [FinanceManagerDb].[dbo].[Merchant] M
    WHERE T.[account_id] = @account_id AND 
        Ty.[types_id] = T.[types_id] AND
        C.[category_id] = T.[category_id] AND
        M.[merchant_id] = T.[merchant_id]
    ORDER BY T.[transaction_Date]
END


-- GetTransactions GroupBy Category By time 
CREATE PROCEDURE GroupByCategorys
(@category_name VARCHAR(32), @date_enrolled DATETIME, @type_groupby VARCHAR, @account_id INT)
AS
BEGIN
SET NOCOUNT ON
IF ('M' = @type_groupby)
begin
    SELECT T.[transaction_id]
        ,T.[transaction_name]
        ,Ty.[icon] TypeIcon
        ,M.[merchant_name]
        ,C.[category_name]
        ,C.[icon] CategoryIcon
        ,C.[color]
        ,T.[transaction_price]
        ,T.[transaction_Date]
        ,T.[image]
        ,T.[transaction_description]
        ,T.[time_stamp]
    FROM [FinanceManagerDb].[dbo].[Transaction_Acc] T,
        [FinanceManagerDb].[dbo].[Types] Ty,
        [FinanceManagerDb].[dbo].[Category] C,
        [FinanceManagerDb].[dbo].[Merchant] M
    WHERE T.[account_id] = @account_id AND 
        Ty.[types_id] = T.[types_id] AND
        C.[category_id] = T.[category_id] AND
        M.[merchant_id] = T.[merchant_id] AND 
        C.[category_name] = @category_name AND
        MONTH(@date_enrolled) = MONTH(T.[transaction_Date]) AND 
        YEAR(@date_enrolled) = YEAR(T.[transaction_Date]) 
    ORDER BY T.[transaction_Date]
end
ELSE 
begin
    SELECT T.[transaction_id]
        ,T.[transaction_name]
        ,Ty.[icon] TypeIcon
        ,M.[merchant_name]
        ,C.[category_name]
        ,C.[icon] CategoryIcon
        ,C.[color]
        ,T.[transaction_price]
        ,T.[transaction_Date]
        ,T.[image]
        ,T.[transaction_description]
        ,T.[time_stamp]
    FROM [FinanceManagerDb].[dbo].[Transaction_Acc] T,
        [FinanceManagerDb].[dbo].[Types] Ty,
        [FinanceManagerDb].[dbo].[Category] C,
        [FinanceManagerDb].[dbo].[Merchant] M
    WHERE T.[account_id] = @account_id AND 
        Ty.[types_id] = T.[types_id] AND
        C.[category_id] = T.[category_id] AND
        M.[merchant_id] = T.[merchant_id] AND 
        C.[category_name] = @category_name AND
        YEAR(@date_enrolled) = YEAR(T.[transaction_Date]) 
    ORDER BY T.[transaction_Date]
end
END

-- Functions 
create function TotalBalance()  
returns decimal(10,2)  
as
begin  
    return (SELECT sum([account_balance]) Sum_1
            FROM [FinanceManagerDb].[dbo].[Account])
end  

print dbo.TotalBalance()



create function NumberOfCards()  
returns INT  
as  
begin  
    return (SELECT count(*)
            FROM [FinanceManagerDb].[dbo].[Account] 
            WHERE (SELECT [types_id] 
                    FROM [FinanceManagerDb].[dbo].[Types] 
                    WHERE [types_name] = 'Credit' ) = [types_id] OR
                  (SELECT [types_id] 
                    FROM [FinanceManagerDb].[dbo].[Types] 
                    WHERE [types_name] = 'Debit' ) = [types_id]) 
end  
print dbo.NumberOfCards()

create function NumberOfUnikBanks()  
returns INT  
as  
begin  
    return (SELECT count(F.Bank_Name) nb 
            FROM (SELECT count(*) Nr_Acc,
                         B.bank_name Bank_Name
                  FROM [FinanceManagerDb].[dbo].[Account] A,
                       [FinanceManagerDb].[dbo].[Bank]  B
                  WHERE B.[bank_id] = A.[bank_id]
                  GROUP BY B.[bank_name]) F)
end 
print dbo.NumberOfUnikBanks()

create function GetNumberOfTransactions(@transtaion_name VARCHAR(32))  
returns INT  
as  
begin  
    return( SELECT count(*) 
            FROM [FinanceManagerDb].[dbo].[Transaction_Acc] T, 
                 [FinanceManagerDb].[dbo].[Types] Ty 
            WHERE Ty.[types_id] = T.[types_id] and 
                  @transtaion_name = Ty.[types_name]
            GROUP BY Ty.[types_name] )
end 
print dbo.GetNumberOfTransactions('Expences')

CREATE PROCEDURE GetSmallStats
AS
BEGIN
SET NOCOUNT ON
SELECT dbo.TotalBalance() total_balance,   
       dbo.GetNumberOfTransactions('Expences') number_expences,
       dbo.GetNumberOfTransactions('Income') number_incoms,
       dbo.NumberOfCards() number_cards,
       dbo.NumberOfUnikBanks() number_banks ;
END

CREATE PROCEDURE GetStatsForASepcificDate
(@type_id INT, @account_id INT, @date_value DATETIME)
AS
BEGIN
SET NOCOUNT ON
    SELECT   [stats_id]
            ,[stats_date]
            ,[types_id]
            ,[account_id]
            ,[incomes]
            ,[expences]
            ,[time_stamp]
    FROM [FinanceManagerDb].[dbo].[Stats]
    WHERE [types_id] = @type_id AND 
        [stats_date] = @date_value AND 
        [account_id] = @account_id
END