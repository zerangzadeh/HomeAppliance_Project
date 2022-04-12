using _01_HA_Framework.Application;
using InventoryManagement.Application.Contracts;
using InventoryManagement.Application.Contracts.Inventory;
using InventoryManagement.Domain.InventoryAgg;
using InventoryManagement.Infrastructure.Repository;

namespace InventoryManagement.Application
{
    public class InventoryApplication : IInventoryApplication
    {

        private readonly IInventoryRepository _inventoryRepository;

        public InventoryApplication(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }

        public OperationResult Create(CreateInventory command)
        {
            var operationResult = new OperationResult();
            var messageForOperation = new MessageForOpeartion();
            if (_inventoryRepository.Exists(x => x.ProductID == command.ProductID))
                 return operationResult.Failed(messageForOperation.DoubleMessage);
            else
            {
                var inventory = new Inventory(command.ProductID,command.UnitPrice);
                _inventoryRepository.Create(inventory);
           
               return operationResult.Succeeded(messageForOperation.SuccessMessage);
            }

        }

        public List<InventoryViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public UpdateInventory GetDetails(long ID)
        {
          return _inventoryRepository.GetDetails(ID);
        }

        public List<InventoryOperationViewModel> GetOperationLog(long inventoryId)
        {
            return _inventoryRepository.GetOperationLog(inventoryId);
        }

        public OperationResult Increase(IncreaseInventory command)
        {
            var operationResult = new OperationResult();
            var messageForOperation = new MessageForOpeartion();
            var inventory = _inventoryRepository.GetBy(command.InventoryID);
            if (inventory == null)
                return operationResult.Failed(messageForOperation.NotFoundMessage);
            const long operatorID = 1;
            inventory.Increase(command.Count, operatorID, command.Description);
            _inventoryRepository.SaveChanges();
            return operationResult.Succeeded(messageForOperation.SuccessMessage);
        }

        public OperationResult Reduce(List<ReduceInventory> command)
        {
            var operationResult = new OperationResult();
            var messageForOperation = new MessageForOpeartion();
            const long operatorID = 1;
            foreach (var item in command)
            {
                var inventory = _inventoryRepository.GetBy(item.InventoryID);
                inventory.Reduce(item.Count, operatorID, item.Description, item.OrderID);

            }
            

            _inventoryRepository.SaveChanges();
            return operationResult.Succeeded(messageForOperation.SuccessMessage);

        }

        public OperationResult Reduce(ReduceInventory command)
        {
            var operationResult = new OperationResult();
            var messageForOperation = new MessageForOpeartion();
            var inventory = _inventoryRepository.GetBy(command.InventoryID);
            if (inventory == null)
                return operationResult.Failed(messageForOperation.NotFoundMessage);
            const long operatorID = 1;
            inventory.Reduce(command.Count, operatorID, command.Description,0);
            _inventoryRepository.SaveChanges();
            return operationResult.Succeeded(messageForOperation.SuccessMessage);
        }

        public List<InventoryViewModel> Search(InventorySearchModel searchModel)
        {
            return _inventoryRepository.Search(searchModel);
        }

        public OperationResult Update(UpdateInventory command)
        {
            var operationResult = new OperationResult();
            var messageForOperation = new MessageForOpeartion();
            var inventory=_inventoryRepository.GetBy(command.ID);
            if (inventory == null)
           
                return operationResult.Failed(messageForOperation.NotFoundMessage);

            if (_inventoryRepository.Exists(x => x.ProductID == command.ProductID && x.ID!=command.ID))
                return operationResult.Failed(messageForOperation.DoubleMessage);
            else
            {
              
                inventory.Update(command.ProductID, command.UnitPrice);
                _inventoryRepository.Update(inventory);
                return operationResult.Succeeded(messageForOperation.SuccessMessage);
            }
        }
    }
}