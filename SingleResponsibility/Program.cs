using SingleResponsibility;

ErrorLogger logger = new ErrorLogger();
Product product = new Product();
if(product.Name == null)
    logger.WriteToErrorLog("path","error");