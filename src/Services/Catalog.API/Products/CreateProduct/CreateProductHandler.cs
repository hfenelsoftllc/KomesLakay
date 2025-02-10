


namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductCommand(string Name, decimal Price, List<string> Category, string Description,  string ImageFile) : ICommand<CreateProductResult>;

    public record CreateProductResult(Guid Id);

    
    internal class CreateProductCommandHandler (IDocumentSession session) : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            // business logic to create a product

            //Vreate Product ENtity from command object
            var  product = new Product
            {
                //Id = Guid.NewGuid(),
                Name = command.Name,
                Price = command.Price,
                Category = command.Category,
                Description = command.Description,
                ImageFile = command.ImageFile
            };

            //Save to database using Marten ORM, Don't use repository pattern hard to change database i need to change all repositories
            session.Store(product);
            await session.SaveChangesAsync(cancellationToken);

            //Return the productResult result
            return new CreateProductResult(product.Id); 
        }
    }
}
