namespace Northwind.Application
{
    public class CustomerTranslator : IEntityTraslator<Model.Customer, Service.Customer>
    {
        internal static IEntityTraslator<Model.Customer, Service.Customer> _instance;

        public static IEntityTraslator<Model.Customer, Service.Customer> Instance
        {
            get
            {
                return _instance ?? (_instance = new CustomerTranslator());
            }
        }
        public Service.Customer CreateDto(Model.Customer model)
        {
            return UpdateDto(new Service.Customer(), model);
        }

        public Model.Customer CreateModel(Service.Customer dto)
        {
            return UpdateModel(new Model.Customer(), dto);
        }

        public Service.Customer UpdateDto(Service.Customer dto, Model.Customer model)
        {
            if (dto.CustomerID != model.CustomerID)
                dto.CustomerID = model.CustomerID;
            if (dto.CompanyName != model.CompanyName)
                dto.CompanyName = model.CompanyName;
            if (dto.ContactName != model.ContactName)
                dto.ContactName = model.ContactName;
            if (dto.Address != model.Address)
                dto.Address = model.Address;
            if (dto.Region != model.Region)
                dto.Region = model.Region;
            if (dto.Country != model.Country)
                dto.Country = model.Country;
            if (dto.PostalCode != model.PostalCode)
                dto.PostalCode = model.PostalCode;
            return dto;
        }

        public Model.Customer UpdateModel(Model.Customer model, Service.Customer dto)
        {
            if (model.CustomerID != dto.CustomerID)
                model.CustomerID = dto.CustomerID;
            if (model.CompanyName != dto.CompanyName)
                model.CompanyName = dto.CompanyName;
            if (model.ContactName != dto.ContactName)
                model.ContactName = dto.ContactName;
            if (model.Address != dto.Address)
                model.Address = dto.Address;
            if (model.City != dto.City)
                model.City = dto.City;
            if (model.Region != dto.Region)
                model.Region = dto.Region;
            if (model.Country != dto.Country)
                model.Country = dto.Country;
            if (model.PostalCode != dto.PostalCode)
                model.PostalCode = dto.PostalCode;
            if (model.Phone != dto.Phone)
                model.Phone = dto.Phone;
            return model;

        }
    }
}
