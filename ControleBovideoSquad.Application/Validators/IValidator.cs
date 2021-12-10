namespace ControleBovideoSquad.Application.Validators
{
    public interface IValidator<T>
    {
        public List<string> IsValid(T value);
        public List<string> errors { get; }
    }
}
