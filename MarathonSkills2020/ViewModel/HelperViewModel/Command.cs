using System;
using System.Windows.Input;

namespace MarathonSkills2020.ViewModel.HelperViewModel
{
    class Command : ICommand
    {
         
        /// <summary>
        /// Событие в котором реализовано поведение на добавление и удаление свойтва 
        /// </summary>

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }

        }

        readonly Action<object> execute;
        readonly Func<object, bool> canExecute;
        private ICommand registrationOnMarathonCommand;

        /// <summary>
        /// Констуруктов в который передаются входные параметры
        /// </summary>
        /// <param name="executeAction">Значение свойства Execute</param>
        /// <param name="canExecuteAction">Значение свойства canExecute</param>

        public Command(Action<object> executeAction, Func<object, bool> canExecuteFunc = null)
        {
            execute = executeAction;
            canExecute = canExecuteFunc;
        }

        public Command(ICommand registrationOnMarathonCommand)
        {
            this.registrationOnMarathonCommand = registrationOnMarathonCommand;
        }

        /// <summary>
        /// Определяет статус возможности нажатия на кнопку
        /// </summary>
        /// <param name="parameter">Имя параметра</param>
        /// <returns>Если canExecute = null, то true иначе присваивает canExecute значение параметра</returns>

        public bool CanExecute(object parameter)
        {
            if (canExecute != null) return canExecute(parameter);
            return true;
        }

        /// <summary>
        /// Метод определяющий поведение на нормальную работу кнопки
        /// </summary>
        /// <param name="parameter">имя свойства</param>
        /// 
        public void Execute(object parameter)
        {
            execute(parameter);
        }
    }
}
