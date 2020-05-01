    /// <summary>
    /// Интерфейс, который является шаблоном для всех кодирующих алгоритмов.
    /// </summary>
    internal interface ICodingMachine
    {
        /// <summary>
        /// Метод, который сжимает текст с помощью кодирующих алгоритмов.
        /// </summary>
        /// <param name="Text"> Текст который надо сжать </param>
        /// <returns> Сжатый текст </returns>
        internal string CompressionText(string Text);
        /// <summary>
        /// Метод, который считает степень сжатия текста.
        /// </summary>
        /// <param name="Text"> Текст который надо сжать </param>
        /// /// <param name="СompressedText"> Сжатый текст </param>
        /// <returns> Степень сжатия текста </returns>
        internal string CompressionRatio(string Text, string СompressedText);
        /// <summary>
        /// Метод, который декодирует сжатый текст.
        /// </summary>
        /// /// <param name="СompressedText"> Текст который надо раскодировать </param>
        /// <returns> Раскодированный текст </returns>
        internal string Decoder(string СompressedText);
    }
