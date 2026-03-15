namespace Api.Services
{
    public static class ServiceProviderExtensions
    {
        public static void PrintServiceDifference<T>(this IServiceProvider services, string scopeName) where T : class, IHasInstanceId
        {
            Console.WriteLine($"\n=== {scopeName} - {typeof(T).Name} ===");

            var first = services.GetService<T>();
            Console.WriteLine($"First: {first?.InstanceId}");

            var second = services.GetService<T>();
            Console.WriteLine($"Second: {second?.InstanceId}");

            if (first == second)
            {
                Console.WriteLine($"✓ Same instance (ReferenceEqual)");
            }
            else
            {
                Console.WriteLine($"✗ Different instances");
            }
        }
    }
}
