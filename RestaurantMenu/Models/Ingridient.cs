namespace RestaurantMenu.Models
{
    public class Ingridient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<DishIngridient>? DishIngridient { get; set; }
    }
}
