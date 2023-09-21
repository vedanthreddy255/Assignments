
ALTER PROCEDURE uspGetUnits
AS
BEGIN

DECLARE cursor_Product Cursor
FOR SELECT UnitsOnOrder,UnitPrice,ProductName FROM Products;

DECLARE @UnitsOnOrder Int,@UnitPrice Int,@ProductName VARCHAR(MAX),@TotalAmount INT,@GrandTotal Decimal;
OPEN cursor_Product;
FETCH NEXT FROM cursor_Product INTO @UnitsOnOrder,@UnitPrice,@ProductName;

While @@FETCH_STATUS=0
BEGIN
SELECT @TotalAmount=@UnitPrice*@UnitsOnOrder FROM Products;
	if @UnitsOnOrder>50 and @UnitsOnOrder<100
	BEGIN
		SELECT @GrandTotal=(@UnitsOnOrder*@UnitPrice)*0.95;
	END
	else if  @UnitsOnOrder>100
	BEGIN
		SELECT @GrandTotal=(@UnitsOnOrder*@UnitPrice)*0.90;
	END
	else
	BEGIN
		SELECT @GrandTotal=(@UnitsOnOrder*@UnitPrice);
	END
	PRINT 'ProductName is ' + @ProductName + ' and Grand Total is ' + CAST(@GrandTotal as VARCHAR);
	FETCH NEXT FROM cursor_Product INTO @UnitsOnOrder,@UnitPrice,@ProductName;
END;

CLOSE cursor_product;
DEALLOCATE cursor_product;
END;



EXEC uspGetUnits
