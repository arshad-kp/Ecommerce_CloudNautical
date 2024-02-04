namespace Ecommerce.Infrastructure.Constants
{
    public static class QueryConstants
    {
        public const string GetOrderDetailsByCustomerId = @"WITH LatestOrderDetails AS 
		(
			SELECT TOP 1 C.FirstName, C.LastName, 
			CASE 
				WHEN OrderId IS NOT NULL
				THEN CONCAT(C.HouseNo,' ', C.Street,' ', C.Town,' ', C.PostCode) 
				ELSE NULL
				END  AS DeliveryAddress,
				O.OrderId, O.OrderDate, O.DeliveryExpected,O.ContainsGift 
			FROM Customers C 
			LEFT JOIN Orders O ON C.CustomerId = O.CustomerId
			WHERE C.CustomerId =  @CustomerId
			ORDER BY O.OrderDate DESC
		)
		SELECT LOD.*, 
		CASE 
			WHEN LOD.ContainsGift = 1
			THEN 'GIFT'
			ELSE P.ProductName
		END AS ProductName,
		OI.Quantity, OI.Price FROM LatestOrderDetails LOD
		LEFT JOIN OrderItems OI ON OI.OrderId = LOD.OrderId
		LEFT JOIN PRODUCTS P ON OI.ProductId = P.ProductId";

        public const string CheckCustomerData = "SELECT 1 FROM CUSTOMERS WHERE CustomerId = @CustomerId AND Email = @Email";
    }
}
