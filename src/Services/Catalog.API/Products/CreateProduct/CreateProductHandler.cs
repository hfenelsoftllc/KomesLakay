using Catalog.API.Models;
using MediatR;
using SharedKernel.CQRS;
using System.Windows.Input;

namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductCommand(string Name, decimal Price, List<string> Category, string Description,  string ImageFile) : ICommand<CreateProductResult>;

    public record CreateProductResult(Guid Id);

    internal class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            // business logic to create a product

            //Vreate Product ENtity from command object
            var product = new Product
            {
                //Id = Guid.NewGuid(),
                Name = command.Name,
                Price = command.Price,
                Category = command.Category,
                Description = command.Description,
                ImageFile = command.ImageFile
            };

            //Save to database using Repository Pattern
            //productRepository.Add(product);
            //await productRepository.UnitOfWork.SaveEntitiesAsync();
            //Return the productResult result
            return  new CreateProductResult(Guid.NewGuid()); 
        }
    }
}
