namespace Infrastructure.Data
{
    public static class SeedingIds
    {
        // Departments
        public static readonly Guid CsDeptId = Guid.Parse("00000000-0000-0000-0000-000000000001");
        public static readonly Guid EeDeptId = Guid.Parse("00000000-0000-0000-0000-000000000002");

        // Courses
        public static readonly Guid DataStructId = Guid.Parse("00000000-0000-0000-0000-000000000011");
        public static readonly Guid AlgorithmsId = Guid.Parse("00000000-0000-0000-0000-000000000012");
        public static readonly Guid DbSystemsId = Guid.Parse("00000000-0000-0000-0000-000000000013");
        public static readonly Guid CircuitsId = Guid.Parse("00000000-0000-0000-0000-000000000021");
        public static readonly Guid LogicDesignId = Guid.Parse("00000000-0000-0000-0000-000000000022");
        public static readonly Guid CalculusId = Guid.Parse("00000000-0000-0000-0000-000000000031");

        // Students
        public static readonly Guid Student1Id = Guid.Parse("00000000-0000-0000-0000-000000000101");
        public static readonly Guid Student2Id = Guid.Parse("00000000-0000-0000-0000-000000000102");
        public static readonly Guid Student3Id = Guid.Parse("00000000-0000-0000-0000-000000000103");
        public static readonly Guid Student4Id = Guid.Parse("00000000-0000-0000-0000-000000000104");
        public static readonly Guid Student5Id = Guid.Parse("00000000-0000-0000-0000-000000000105");

        // Teachers
        public static readonly Guid Teacher1Id = Guid.Parse("00000000-0000-0000-0000-000000000201");
        public static readonly Guid Teacher2Id = Guid.Parse("00000000-0000-0000-0000-000000000202");
        public static readonly Guid Teacher3Id = Guid.Parse("00000000-0000-0000-0000-000000000203");
    }
}