
CREATE FUNCTION [dbo].[GetNewAmount] (@DepositId int)
RETURNS money
AS
BEGIN
   DECLARE @NewAmount money = (SELECT TOP 1 Amount FROM DepositPayment where @DepositId = DepositPayment.DepositId ORDER BY Date DESC)
    
   RETURN(@NewAmount);
END;	

CREATE FUNCTION [dbo].[getamount] (@DepositTypeId int, @Balance money)
RETURNS money
AS
BEGIN
   DECLARE @percent float = (SELECT TOP 1 [Percent] FROM DepositType where DepositType.Id = @DepositTypeId)
    
   RETURN(@percent * @Balance/100);
END; 

CREATE PROCEDURE [dbo].[DepositOvercharge]   
AS 
	DECLARE @date datetime = GETDATE()
	INSERT INTO DepositPayment (DepositId, Amount, [Type], Date) 
	SELECT Deposit.Id, dbo.getamount(Deposit.DepositTypeId, Deposit.Balance), 2, @date from Deposit
	UPDATE Deposit SET Balance = Balance + dbo.GetNewAmount(Deposit.Id)
