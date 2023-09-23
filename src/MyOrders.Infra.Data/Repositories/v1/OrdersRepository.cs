using Microsoft.EntityFrameworkCore;
using MyOrders.Domain.Contracts.v1.Repository;
using MyOrders.Domain.Entities.v1;
using MyOrders.Infra.Data.Context.v1;

namespace MyOrders.Infra.Data.Repositories.v1;

public class OrdersRepository : IOrdersRepository
{
    private readonly DbContextClass _context;

    public OrdersRepository(DbContextClass context)
    {
        _context = context;
    }

    public async Task<Order> CreateOrderAsync(Order order)
    {
        try
        {
            var result = _context.Orders!.Add(order);
            await _context.SaveChangesAsync();

            return result.Entity;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<int> DeleteOrderAsync(Order order)
    {
        try
        {
            _context.Orders!.Remove(order);
            return await _context.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<Order> GetOrderByIdAsync(int id)
    {
        var order = await _context.Orders!.FirstOrDefaultAsync(o => o.Id == id);
        return order!;
    }

    public async Task<IEnumerable<Order>> GetOrdersAsync()
    {
        try
        {
            return await _context.Orders!.ToListAsync();
        }
        catch (Exception)
        {

            throw;
        }
    }

    public async Task<int> UpdateOrderAsync(Order order)
    {
        try
        {
            _context.Entry(order).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }
        catch (Exception)
        {

            throw;
        }
    }
}
