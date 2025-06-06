using System;
using ZooManagementSystem.Models;
using ZooManagementSystem.Services;

namespace ZooManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var zooManager = new ZooManager();
            var menu = new MenuService(zooManager);
            menu.ShowMainMenu();
        }
    }
}
