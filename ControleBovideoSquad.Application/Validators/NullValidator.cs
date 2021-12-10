namespace ControleBovideoSquad.Application.Validators
{
    public class NullValidator<T> : IValidator<T>
    {
        public NullValidator()
        {
            errors = new List<string>();
        }

        public List<string> errors { get; }

        public List<string> IsValid(T value)
        {
            if (value != null)
                foreach (var item in value.GetType().GetProperties())
                {

                    if (item.GetValue(value)?.ToString() is null or "" && item.PropertyType.IsValueType)
                    {
                        errors.Add($"{item.Name} não pode ser Nulo");
                    }
                }

            return errors;
        }
    }
}
