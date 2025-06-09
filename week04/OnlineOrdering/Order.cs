using System;
using System.Collections.Generic;

class Order
{

    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double GetTotalCost()
    {
        double total = 0;
        foreach (var product in _products)
        {
            total += product.GetTotalCost();
        }
        total += _customer.LivesInUSA() ? 5 : 35; //add shipping cost if not in USA
        // (? 0 :) if customer lives in USA, no shipping cost
        return total;
    }
    public string GetPackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (var product in _products)
        {
            label += $"{product.GetName()} (ID: {product.GetProductId()}): ${product.GetPrice()} x {product.GetQuantity()} = ${product.GetTotalCost()}\n";
        }
        return label;
    }
    public Customer GetCustomer()
    {
        return _customer;
    }
    public string GetShippingLabel()
    {
        return $"Shipping Label:\nCustomer: {_customer.GetName()}\nAddress: {_customer.GetAddress().GetFullAddress()}";
    }
}
