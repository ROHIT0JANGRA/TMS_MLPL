using CodeLock.Areas.Contract.Repository;
using CodeLock.Areas.Finance.Repository;
using CodeLock.Areas.FMS.Repository;
using CodeLock.Areas.Master.Repository;
using CodeLock.Areas.Operation.Repository;
using CodeLock.Areas.Reports.Repository;
using CodeLock.Areas.WMS.Repository;
using CodeLock.Models;
using CodeLock.Repository;
using Unity;
using Unity.Injection;
using System.Web.Mvc;
using System.ComponentModel;
using System.Web.Http;
using CodeLock.Areas.Packaging.Repository;

namespace CodeLock
{
    public static class IocConfig
    {
        public static void ConfigureIocUnityContainer()
        {
            IUnityContainer unityContainer = (IUnityContainer)new UnityContainer();
            IocConfig.registerServices(unityContainer);
            DependencyResolver.SetResolver((IDependencyResolver)new UnityDependencyResolver(unityContainer));
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(unityContainer);
        }

        private static void registerServices(IUnityContainer container)
        {
            container.RegisterType<IHomeRepository, HomeRepository>(new InjectionMember[0]);
            container.RegisterType<ICountryRepository, CountryRepository>(new InjectionMember[0]);
            container.RegisterType<IUserRepository, UserRepository>(new InjectionMember[0]);
            container.RegisterType<ICompanyRepository, CompanyRepository>(new InjectionMember[0]);
            container.RegisterType<ILocationRepository, LocationRepository>(new InjectionMember[0]);
            container.RegisterType<IWarehouseRepository, WarehouseRepository>(new InjectionMember[0]);
            container.RegisterType<IMenuRepository, MenuRepository>(new InjectionMember[0]);
            container.RegisterType<IGeneralRepository, GeneralRepository>(new InjectionMember[0]);
            container.RegisterType<IPincodeRepository, PincodeRepository>(new InjectionMember[0]);
            container.RegisterType<IStateRepository, StateRepository>(new InjectionMember[0]);
            container.RegisterType<IZoneRepository, ZoneRepository>(new InjectionMember[0]);
            container.RegisterType<IDocketRepository, DocketRepository>(new InjectionMember[0]);
            container.RegisterType<ICustomerRepository, CustomerRepository>(new InjectionMember[0]);
            container.RegisterType<ICustomerGroupRepository, CustomerGroupRepository>(new InjectionMember[0]);
            container.RegisterType<ICityRepository, CityRepository>(new InjectionMember[0]);
            container.RegisterType<IFieldsRepository, FieldsRepository>(new InjectionMember[0]);
            container.RegisterType<IRulesRepository, RulesRepository>(new InjectionMember[0]);
            container.RegisterType<ISupervisorRepository, SupervisorRepository>(new InjectionMember[0]);
            container.RegisterType<IBinHierarchyRepository, BinHierarchyRepository>(new InjectionMember[0]);
            container.RegisterType<IVehicleRepository, VehicleRepository>(new InjectionMember[0]);
            container.RegisterType<IBinsRepository, BinsRepository>(new InjectionMember[0]);
            container.RegisterType<IProductRepository, ProductRepository>(new InjectionMember[0]);
            container.RegisterType<IAddressRepository, AddressRepository>(new InjectionMember[0]);
            container.RegisterType<ICustomerAddressRepository, CustomerAddressRepository>(new InjectionMember[0]);
            container.RegisterType<IVendorRepository, VendorRepository>(new InjectionMember[0]);
            container.RegisterType<ISupplierRepository, SupplierRepository>(new InjectionMember[0]);
            container.RegisterType<IReceiverRepository, ReceiverRepository>(new InjectionMember[0]);
            container.RegisterType<IVehicleDocumentTypeRepository, VehicleDocumentTypeRepository>(new InjectionMember[0]);
            container.RegisterType<IVehicleTypeRepository, VehicleTypeRepository>(new InjectionMember[0]);
            container.RegisterType<IDcrRepository, DcrRepository>(new InjectionMember[0]);
            container.RegisterType<IAccountRepository, AccountRepository>(new InjectionMember[0]);
            container.RegisterType<IAccountCategoryRepository, AccountCategoryRepository>(new InjectionMember[0]);
            container.RegisterType<IAccountGroupRepository, AccountGroupRepository>(new InjectionMember[0]);
            container.RegisterType<IHolidayDateWiseRepository, HolidayDateWiseRepository>(new InjectionMember[0]);
            container.RegisterType<IHolidayDayWiseRepository, HolidayDayWiseRepository>(new InjectionMember[0]);
            container.RegisterType<IAssetRepository, AssetRepository>(new InjectionMember[0]);
            container.RegisterType<IRoleRepository, RoleRepository>(new InjectionMember[0]);
            container.RegisterType<IDriverRepository, DriverRepository>(new InjectionMember[0]);
            container.RegisterType<IRouteRepository, RouteRepository>(new InjectionMember[0]);
            container.RegisterType<ICustomerContractRepository, CustomerContractRepository>(new InjectionMember[0]);
            container.RegisterType<IGstRepository, GstRepository>(new InjectionMember[0]);
            container.RegisterType<ISacRepository, SacRepository>(new InjectionMember[0]);
            container.RegisterType<IUserCompanyRepository, UserCompanyRepository>(new InjectionMember[0]);
            container.RegisterType<IAirportRepository, AirportRepository>(new InjectionMember[0]);
            container.RegisterType<IThcRepository, ThcRepository>(new InjectionMember[0]);
            container.RegisterType<ILoadingSheetRepository, LoadingSheetRepository>(new InjectionMember[0]);
            container.RegisterType<IManifestRepository, ManifestRepository>(new InjectionMember[0]);
            container.RegisterType<IVendorContractRepository, VendorContractRepository>(new InjectionMember[0]);
            container.RegisterType<IDrsRepository, DrsRepository>(new InjectionMember[0]);
            container.RegisterType<IPrsRepository, PrsRepository>(new InjectionMember[0]);
            container.RegisterType<ICustomerBillRepository, CustomerBillRepository>(new InjectionMember[0]);
            container.RegisterType<IVendorPaymentRepository, VendorPaymentRepository>(new InjectionMember[0]);
            container.RegisterType<IConsignorConsigneeRepository, ConsignorConsigneeRepository>(new InjectionMember[0]);
            container.RegisterType<IUserWarehouseRepository, UserWarehouseRepository>(new InjectionMember[0]);
            container.RegisterType<CodeLock.Areas.Operation.Repository.ITrackingRepository, CodeLock.Areas.Operation.Repository.TrackingRepository>(new InjectionMember[0]);
            container.RegisterType<IFlightRepository, FlightRepository>(new InjectionMember[0]);
            container.RegisterType<IPfmRepository, PfmRepository>(new InjectionMember[0]);
            container.RegisterType<IFuelBrandRepository, FuelBrandRepository>(new InjectionMember[0]);
            container.RegisterType<IDocumentControlRepository, DocumentControlRepository>(new InjectionMember[0]);
            container.RegisterType<ICustomerBillFormatRepository, CustomerBillFormatRepository>(new InjectionMember[0]);
            container.RegisterType<IOperationRepository, OperationRepository>(new InjectionMember[0]);
            container.RegisterType<IPackagingMeasurementRepository, PackagingMeasurementRepository>(new InjectionMember[0]);
            container.RegisterType<IFuelSurchargeRevisioinRepository, FuelSurchargeRevisioinRepository>(new InjectionMember[0]);
            container.RegisterType<IChargeRepository, ChargeRepository>(new InjectionMember[0]);
            container.RegisterType<IBankingRepository, BankingRepository>(new InjectionMember[0]);
            container.RegisterType<IAccountsRepository, AccountsRepository>(new InjectionMember[0]);
            container.RegisterType<IQuickDocketRepository, QuickDocketRepository>(new InjectionMember[0]);
            container.RegisterType<ITripsheetRepository, TripsheetRepository>(new InjectionMember[0]);
            container.RegisterType<IRouteCityWiseRepository, RouteCityWiseRepository>(new InjectionMember[0]);
            container.RegisterType<ICardRepository, CardRepository>(new InjectionMember[0]);
            container.RegisterType<ITripCheckListRepository, TripCheckListRepository>(new InjectionMember[0]);
            container.RegisterType<CodeLock.Areas.Finance.Repository.ITrackingRepository, CodeLock.Areas.Finance.Repository.TrackingRepository>(new InjectionMember[0]);
            container.RegisterType<IHsnRepository, HsnRepository>(new InjectionMember[0]);
            container.RegisterType<CodeLock.Areas.FMS.Repository.ITrackingRepository, CodeLock.Areas.FMS.Repository.TrackingRepository>(new InjectionMember[0]);
            container.RegisterType<IJobOrderWorkGroupRepository, JobOrderWorkGroupRepository>(new InjectionMember[0]);
            container.RegisterType<IJobOrderTaskTypeRepository, JobOrderTaskTypeRepository>(new InjectionMember[0]);
            container.RegisterType<IJobOrderTaskRepository, JobOrderTaskRepository>(new InjectionMember[0]);
            container.RegisterType<IJobOrderRepository, JobOrderRepository>(new InjectionMember[0]);
            container.RegisterType<ISkuRepository, SkuRepository>(new InjectionMember[0]);
            container.RegisterType<IAccountOpeningRepository, AccountOpeningRepository>(new InjectionMember[0]);
            container.RegisterType<IAccountOpeningPartyRepository, AccountOpeningPartyRepository>(new InjectionMember[0]);
            container.RegisterType<IGrnRepository, GrnRepository>(new InjectionMember[0]);
            container.RegisterType<IJobOrderApprovalMatrixRepository, JobOrderApprovalMatrixRepository>(new InjectionMember[0]);
            container.RegisterType<IExpenseContractRepository, ExpenseContractRepository>(new InjectionMember[0]);
            container.RegisterType<IBudgetRepository, BudgetRepository>(new InjectionMember[0]);
            container.RegisterType<IPurchaseOrderRepository, PurchaseOrderRepository>(new InjectionMember[0]);
            container.RegisterType<IDashboardRepository, DashboardRepository>(new InjectionMember[0]);
            container.RegisterType<IDispatchRepository, DispatchRepository>(new InjectionMember[0]);
            container.RegisterType<IInspectionRepository, InspectionRepository>(new InjectionMember[0]);
            container.RegisterType<IVehicleColdChainRateRepository, VehicleColdChainRateRepository>(new InjectionMember[0]);
            container.RegisterType<IUnitTemperatureRepository, UnitTemperatureRepository>(new InjectionMember[0]);
            container.RegisterType<IProductTemperatureRepository, ProductTemperatureRepository>(new InjectionMember[0]);
            container.RegisterType<IFinancialYearRightRepository, FinancialYearRightRepository>(new InjectionMember[0]);
            container.RegisterType<IRoleBasedAccessRightRepository, RoleBasedAccessRightRepository>(new InjectionMember[0]);
            container.RegisterType<ITripsheetBillRepository, TripsheetBillRepository>(new InjectionMember[0]);
            container.RegisterType<IVehicleCapacityRateRepository, VehicleCapacityRateRepository>(new InjectionMember[0]);
            container.RegisterType<IVendorDocumentApprovalRepository, VendorDocumentApprovalRepository>(new InjectionMember[0]);
            container.RegisterType<IIssueRepository, IssueRepository>(new InjectionMember[0]);
            container.RegisterType<ILocationHierarchyRepository, LocationHierarchyRepository>(new InjectionMember[0]);
            container.RegisterType<ISkuLocationMappingRepository, SkuLocationMappingRepository>(new InjectionMember[0]);
            container.RegisterType<IGatePassRepository, GatePassRepository>(new InjectionMember[0]);
            container.RegisterType<ICustomerPanelRepository, CustomerPanelRepository>(new InjectionMember[0]);
            container.RegisterType<ILaneRepository, LaneRepository>(new InjectionMember[0]);
            container.RegisterType<IFSCRateRepository, FSCRateRepository>(new InjectionMember[0]);
            container.RegisterType<IPartRepository, PartRepository>(new InjectionMember[0]);
            container.RegisterType<ITyreSizeRepository, TyreSizeRepository>(new InjectionMember[0]);
            container.RegisterType<ITyrePositionRepository, TyrePositionRepository>(new InjectionMember[0]);
            container.RegisterType<ITyrePatternRepository, TyrePatternRepository>(new InjectionMember[0]);
            container.RegisterType<ITyreManufacturerRepository, TyreManufacturerRepository>(new InjectionMember[0]);
            container.RegisterType<ITyreManufacturerRepository, TyreManufacturerRepository>(new InjectionMember[0]);
            container.RegisterType<ITyreModelRepository, TyreModelRepository>(new InjectionMember[0]);
            container.RegisterType<IFinanceRepository, FinanceRepository>(new InjectionMember[0]);
            //  container.RegisterType<IBusinousPatnerApi,BusinousPatnerApi>(new InjectionMember[0]);
            container.RegisterType<IRgpRepository, RgpRepository>(new InjectionMember[0]);


        }
    }
}
