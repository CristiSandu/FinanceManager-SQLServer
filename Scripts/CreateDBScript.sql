CREATE DATABASE FinanceManagerDb

USE FinanceManagerDb;
GO

DROP TABLE IF EXISTS Stats;
GO
DROP TABLE IF EXISTS Transaction_Acc;
GO
DROP TABLE IF EXISTS Account;
GO
DROP TABLE IF EXISTS Merchant;
GO
DROP TABLE IF EXISTS Types;
GO
DROP TABLE IF EXISTS Bank;
GO
DROP TABLE IF EXISTS Category;
GO

CREATE TABLE Category(
     category_id INTEGER IDENTITY(1,1)
    ,category_name VARCHAR(35) CONSTRAINT category_name_nn NOT NULL
    ,icon VARCHAR(35)
    ,time_stamp DATETIME
    ,color VARCHAR(35)
    ,CONSTRAINT category_id_pk PRIMARY KEY(category_id)
);

CREATE TABLE Bank(
      bank_id INTEGER IDENTITY(1,1)
    ,bank_name VARCHAR(35) CONSTRAINT bank_name_nn NOT NULL
    ,bank_description VARCHAR(50)
    ,image varbinary(50)
    ,time_stamp DATETIME
    ,CONSTRAINT bank_id_pk PRIMARY KEY(bank_id)
);
CREATE TABLE Types(
     types_id INTEGER IDENTITY(1,1)
    ,types_name VARCHAR(35) CONSTRAINT types_name_nn NOT NULL
    ,table_name VARCHAR(35)
    ,icon VARCHAR(35)
    ,CONSTRAINT types_id_pk PRIMARY KEY(types_id)
);

CREATE TABLE Merchant(
    merchant_id INTEGER IDENTITY(1,1)
    ,merchant_name VARCHAR(35) CONSTRAINT merchant_name_nn NOT NULL
    ,category_id INTEGER
    ,merchant_description VARCHAR(50)
    ,time_stamp DATETIME
    ,CONSTRAINT merchant_id_pk PRIMARY KEY(merchant_id)
    ,CONSTRAINT category_id_fk FOREIGN KEY(category_id) REFERENCES Category(category_id)
);

CREATE TABLE Account(
      account_id INTEGER IDENTITY(1,1)
    ,account_name VARCHAR(35) CONSTRAINT account_name_nn NOT NULL
    ,types_id INTEGER 
    ,bank_id INTEGER
    ,account_balance float
    ,account_IBAN VARCHAR(50)
    ,time_stamp DATETIME
    ,account_holder VARCHAR(50)
    ,CONSTRAINT acc_iban_uk   UNIQUE(account_IBAN)
    ,CONSTRAINT acc_name_uk   UNIQUE(account_name)
    ,CONSTRAINT account_id_pk PRIMARY KEY(account_id)
    ,CONSTRAINT bank_id_fk FOREIGN KEY(bank_id) REFERENCES Bank(bank_id)
    ,CONSTRAINT types_id_fk FOREIGN KEY(types_id) REFERENCES Types(types_id)
);

CREATE TABLE Transaction_Acc(
     transaction_id INTEGER IDENTITY(1,1)
    ,transaction_name VARCHAR(35) CONSTRAINT transaction_name_nn NOT NULL
    ,types_id INTEGER
    ,merchant_id INTEGER
    ,account_id INTEGER
    ,category_id INTEGER
    ,transaction_price float CONSTRAINT transaction_price_nn NOT NULL
    ,transaction_Date DATE CONSTRAINT transaction_Date_nn NOT NULL
    ,image varbinary(50)
    ,transaction_description VARCHAR(50)
    ,time_stamp DATETIME CONSTRAINT transaction_time_stamp_nn NOT NULL
    ,CONSTRAINT transaction_id_pk PRIMARY KEY(transaction_id)
    ,CONSTRAINT types_id_trans_fk FOREIGN KEY(types_id) REFERENCES Types(types_id)
    ,CONSTRAINT merchant_id_fk FOREIGN KEY(merchant_id) REFERENCES Merchant(merchant_id)
    ,CONSTRAINT account_id_trans_fk FOREIGN KEY(account_id) REFERENCES Account(account_id) ON DELETE CASCADE
    ,CONSTRAINT category_id_trans_fk FOREIGN KEY(category_id) REFERENCES Category(category_id)
);

CREATE TABLE Stats(
     stats_id INTEGER IDENTITY(1,1)
    ,stats_date DATE CONSTRAINT stats_date_nn NOT NULL
    ,types_id INTEGER 
    ,account_id INTEGER
    ,incomes float
    ,expences float
    ,time_stamp DATETIME
    ,CONSTRAINT stats_id_pk PRIMARY KEY(stats_id)
    ,CONSTRAINT account_id_fk FOREIGN KEY(account_id) REFERENCES Account(account_id) ON DELETE CASCADE
    ,CONSTRAINT types_id_stat_fk FOREIGN KEY(types_id) REFERENCES Types(types_id)
);
GO

INSERT INTO Types VALUES( 'Income','Transaction','arrow-up');
INSERT INTO Types VALUES( 'Expences','Transaction','arrow-down');
INSERT INTO Types VALUES( 'Credit','Account','credit-card');
INSERT INTO Types VALUES( 'Debit','Account','credit-card');
INSERT INTO Types VALUES( 'Cash','Account','money-bill-alt');
INSERT INTO Types VALUES( 'Month','Stats','M');
INSERT INTO Types VALUES( 'Day','Stats','D');
INSERT INTO Types VALUES( 'Year','Stats','Y');
GO

INSERT INTO Category VALUES('Food','utensils',CONVERT(DATETIME, '2022-01-01'),'#28A32E');
INSERT INTO Category VALUES('Uncategorized expenses','question-circle',CONVERT(DATETIME, '2022-01-01'),'#C4C4C4');
INSERT INTO Category VALUES('Holidays/Travel/Free time','plane-arrival',CONVERT(DATETIME, '2022-01-01'),'#FFD4C6');
INSERT INTO Category VALUES('Communications and Media','desktop',CONVERT(DATETIME, '2022-01-01'),'#CE1E07');
INSERT INTO Category VALUES('Recurring income','undo',CONVERT(DATETIME, '2022-01-01'),'#84E721' );
INSERT INTO Category VALUES('Deposit','shopping-basket',CONVERT(DATETIME, '2022-01-01'),'#C1FFF2');
INSERT INTO Category VALUES('Transport','subway',CONVERT(DATETIME, '2022-01-01'),'#F2CB00');
INSERT INTO Category VALUES('Clothes','tshirt',CONVERT(DATETIME, '2022-01-01'),'#62C7CE');
INSERT INTO Category VALUES('Withdrawals','money-bill-alt',CONVERT(DATETIME, '2022-01-01'),'#FFFE73');
GO

INSERT INTO Bank VALUES('BCR',null,null,CONVERT(DATETIME, '2022-01-01'));
INSERT INTO Bank VALUES('Revolut',null,null,CONVERT(DATETIME, '2022-01-01'));
INSERT INTO Bank VALUES('BRD',null,null,CONVERT(DATETIME, '2022-01-01'));
INSERT INTO Bank VALUES('BT',null,null,CONVERT(DATETIME, '2022-01-01'));
INSERT INTO Bank VALUES('CEC',null,null,CONVERT(DATETIME, '2022-01-01'));
INSERT INTO Bank VALUES('Raiffeisen',null,null,CONVERT(DATETIME, '2022-01-01'));
INSERT INTO Bank VALUES('UniCredit',null,null,CONVERT(DATETIME, '2022-01-01'));
INSERT INTO Bank VALUES('Cash',null,null,CONVERT(DATETIME, '2022-01-01'));
GO

INSERT INTO Account VALUES('BCR User1',4,1,2000,'RO79 RNCB 0205 1519 1020 0001',CONVERT(DATETIME, '2022-01-01'),'Sandu Ilie-Cristian');
INSERT INTO Account VALUES('Revolut User1',4,2,2000,'RO79 RNCB 0205 1519 1020 0002',CONVERT(DATETIME, '2022-01-01'),'Sandu Ilie-Cristian');
INSERT INTO Account VALUES('BRD User1',4,3,2000,'RO79 RNCB 0205 1519 1020 0003',CONVERT(DATETIME, '2022-01-01'),'Sandu Ilie-Cristian');
INSERT INTO Account VALUES('BT User1',4,4,2000,'RO79 RNCB 0205 1519 1020 0004',CONVERT(DATETIME, '2022-01-01'),'Sandu Ilie-Cristian');
INSERT INTO Account VALUES('CEC User1',4,5,2000,'RO79 RNCB 0205 1519 1020 0005',CONVERT(DATETIME, '2022-01-01'),'Sandu Ilie-Cristian');
INSERT INTO Account VALUES('Raiffeisen User1',4,6,2000,'RO79 RNCB 0205 1519 1020 0006',CONVERT(DATETIME, '2022-01-01'),'Sandu Ilie-Cristian');
INSERT INTO Account VALUES('UniCredit User1',4,7,2000,'RO79 RNCB 0205 1519 1020 0007',CONVERT(DATETIME, '2022-01-01'),'Sandu Ilie-Cristian');
INSERT INTO Account VALUES('Cash User1',5,8,2000,null,CONVERT(DATETIME, '2022-01-01'),'Sandu Ilie-Cristian');
GO

INSERT INTO Merchant VALUES('KFC',1,'Lorem ipsum dolorse  platea dictumst. ',CONVERT(DATETIME, '2022-01-01'));
INSERT INTO Merchant VALUES('Enel',2,'Proin auctor, teip  luctus fringilla ut sit a',CONVERT(DATETIME, '2022-01-01'));
INSERT INTO Merchant VALUES('Cinema City',3,'Quisque pull felis. ',CONVERT(DATETIME, '2022-01-01'));
INSERT INTO Merchant VALUES('Digi',4,'Curabitur ac maxve In.',CONVERT(DATETIME, '2022-01-01'));
INSERT INTO Merchant VALUES('UPB',5,'Pellentesque vehiid velit in, tristique ',CONVERT(DATETIME, '2022-01-01'));
INSERT INTO Merchant VALUES('Lidl',6,'Auris molestie i. E iaculis neque, a .',CONVERT(DATETIME, '2022-01-01'));
INSERT INTO Merchant VALUES('Metrorex',7,'Cras vulputadap gravida convallis at et augue.',CONVERT(DATETIME, '2022-01-01'));
INSERT INTO Merchant VALUES('NewYorker',8,'Nunc ornare',CONVERT(DATETIME, '2022-01-01'));
INSERT INTO Merchant VALUES('ATM Big',9,'Donec mattis ut eleifend dui fringilla quis.',CONVERT(DATETIME, '2022-01-01'));
GO
