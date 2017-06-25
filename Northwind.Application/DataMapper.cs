namespace Northwind.Application
{
    public static class DataMapper
    {
        public static Model.Customer Update(this Model.Customer model, Northwind.Application.CustomerService.Customer dto)
        {
            model.Address = dto.Address;
            model.City = dto.City;
            model.CompanyName = dto.CompanyName;
            model.ContactName = dto.ContactName;
            model.Country = dto.Country;
            model.CustomerID = dto.CustomerID;
            model.Phone = dto.Phone;
            model.PostalCode = dto.PostalCode;
            model.Region = dto.Region;

            return model;
        }
    }
}
