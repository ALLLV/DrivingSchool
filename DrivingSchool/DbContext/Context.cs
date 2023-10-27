using DrivingSchool.Db;

namespace DrivingSchool.DbContext
{
    internal static class Context
    {
        private static Entities dbContext = new Entities();
        public static Entities DbContext { get { return dbContext; } }
    }
}
