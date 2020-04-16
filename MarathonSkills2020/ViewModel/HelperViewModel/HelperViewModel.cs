using System;
using System.Windows;

namespace MarathonSkills2020.ViewModel.HelperViewModel
{
    class HelperViewModel : ViewModelProp
    {
        protected Model.context context = new Model.context();

        public static void MessageBoxErrorStatic(Exception ex)
        {
            MessageBox.Show(ex.Message, ex.HelpLink, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        protected void MessageBoxError(Exception ex)
        {
            MessageBox.Show(ex.Message, ex.HelpLink, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        protected void MessageBoxError(string msg, string title = "Ошибка")
        {
            MessageBox.Show(msg, title, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        protected void MessageBoxWarning(string msg, string title = "Проверьте данные")
        {
            MessageBox.Show(msg, title, MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        protected void MessageBoxInformation(string msg, string title = "Успешно")
        {
            MessageBox.Show(msg, title, MessageBoxButton.OK, MessageBoxImage.Information);
        }

        protected MessageBoxResult MessageBoxQuestion(string msg, string title = "Вопрос")
        {
            return MessageBox.Show(msg, title, MessageBoxButton.YesNo, MessageBoxImage.Question);
        }
    }
}

