using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class VendingMachine
    {
        private List<Product> _products;
        private int _balance;
        private int _income;
        public int Balance { get { return _balance; } }
        public int Income { get { return _income; } }
        private ProductCategory ParseCategory(string parameter)
        {

            if ("Drinks" == parameter)
            {
                return ProductCategory.Drink;
            }
            else if ("Food" == parameter)
            {
                return ProductCategory.Food;
            }
            else if ("Snack" == parameter)
            {
                return ProductCategory.Snack;
            }
            else { return ProductCategory.Snack; }

        }
        public void LoadProducts(string FileName)
        {
            _products = new List<Product>();
            string[] lines = File.ReadAllLines(FileName);
            foreach (string line in lines)
            {
                string[] splitline = line.Split(";");
                _products.Add(new Product(splitline[0], splitline[1], int.Parse(splitline[2]), int.Parse(splitline[3]), ParseCategory(splitline[4])));
            }
            
        }
        public VendingMachine(string FileName)
        {
            _balance = 0;
            _income = 0;
            LoadProducts(FileName);
        }
        public void InsertCoin(int Coin)
        {
            _balance += Coin;
        }
        public int ReturnChange()
        {
            int num = _balance;
            _balance = 0;
            return num;

        }

    }
}
