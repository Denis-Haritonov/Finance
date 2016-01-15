
CREATE FUNCTION [dbo].[GetCreditPaymentAmount] (@CreditTypeId int, @MainDebt money)
RETURNS money
AS
BEGIN
   DECLARE @percent float = (SELECT TOP 1 [Percent] FROM CreditType where CreditType.Id = @CreditTypeId)
    
   RETURN(@percent * @MainDebt);
END;

CREATE FUNCTION [dbo].[GetNewCreditPaymentAmount] (@CreditId int)
RETURNS money
AS
BEGIN
   DECLARE @NewAmount money = (SELECT TOP 1 PercentsAmount FROM CreditPayment where @CreditId = CreditPayment.CreditId ORDER BY Date DESC)
    
   RETURN(@NewAmount);
END;

CREATE PROCEDURE [dbo].[CreditOvercharge]   
AS 
	DECLARE @date datetime = GETDATE()
	INSERT INTO CreditPayment (CreditId, PercentsAmount, MainAmount, [Type], Date) 
	SELECT Credit.Id, dbo.GetCreditPaymentAmount(Credit.CreditTypeId, Credit.MainDebt), 0, 1, @date from Credit
	WHERE Credit.MainAmount > 0
	
	UPDATE Credit SET PercentageDebt = PercentageDebt + dbo.GetNewCreditPaymentAmount(Credit.Id)
	WHERE Credit.MainAmount > 0