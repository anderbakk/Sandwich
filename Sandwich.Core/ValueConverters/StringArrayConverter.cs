namespace Sandwich.Core.ValueConverters
{
    public class StringArrayConverter : ListConverterBase<string[]>
    {
        public StringArrayConverter(char separator) : base(separator)
        {
        }

        protected override string[] InternalConvert(string[] values)
        {
            return values;
        }
    }
}