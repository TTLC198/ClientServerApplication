using PStudioLibrary;

namespace ServerUnitTest
{
    public static class Values
    {
        public static User testCuUser = new User()
        {
            email = "test@email.com",
            login = "c1",
            name = "customer",
            password = "c1",
            role = "Клиент"
        };

        public static User testPhUser = new User()
        {
            email = "test@email.com",
            login = "p1",
            name = "photographer",
            password = "p1",
            role = "Исполнитель"
        };
        
        public static Order testOrder = new Order()
        {
            isCompleted = false,
            message = "Some about order"
        };
    }
}