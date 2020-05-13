using System;
using System.Windows;
using System.Windows.Controls;

namespace MarathonSkills2020.ViewModel.HelperViewModel
{
    public delegate void SetPageDelegate(Page page);
    class HelperViewModel : ViewModelProp
    {
        protected Model.context context = new Model.context();
        public static SetPageDelegate setPage { get; set; }

        public static void SetPage(Page page)
        {
            setPage?.Invoke(page);
        }

        public static void MessageBoxErrorStatic(Exception ex)
        {
            MessageBox.Show(ex.Message, ex.HelpLink, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        protected void MessageBoxError(Exception ex)
        {
            MessageBox.Show(ex.Message, ex.HelpLink, MessageBoxButton.OK, MessageBoxImage.Error);
        }


        protected void MessageBoxError(string message, string title = "Ошибка")
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        protected void MessageBoxWarning(string message, string title = "Проверьте данные")
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        protected void MessageBoxInformation(string message, string title = "Успешно")
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Information);
        }

        protected MessageBoxResult MessageBoxQuestion(string message, string title = "Вопрос")
        {
            MessageBoxResult result = MessageBox.Show(message, title, MessageBoxButton.YesNo, MessageBoxImage.Question);
            return result;
        }

    }
}

