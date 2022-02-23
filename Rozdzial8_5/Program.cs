using System;

namespace Rozdzial8_5
{
    // Ułatwienie hermetyzacji i polimorfizmu dzięki składowym interfejsu z modyfikatorem protected
    public interface IWorkflowActivity
    {
        // Prywatna, a więc niewirtualna
        private void Start() =>
        Console.WriteLine("IWorkflowActivity.Start()...");

        // Modyfikator sealed uniemożliwia przesłanianie
        sealed void Run()
        {
            try
            {
                Start();
                InternalRun();
            }
            finally
            {
                Stop();
            }
        }
        protected void InternalRun();

        // Prywatna, a więc niewirtualna
        private void Stop() =>
        Console.WriteLine("IWorkflowActivity.Stop()..");
    }
    public interface IExecuteProcessActivity : IWorkflowActivity
    {
        protected virtual void RedirectStandardInOut() => Console.WriteLine("IExecuteProcessActivity.RedirectStandardInOut()...");
        // Jeśli metoda jest przesłaniana, nie można używać modyfikatora sealed
        /* sealed */ void IWorkflowActivity.InternalRun()
        {
            RedirectStandardInOut();
            ExecuteProcess();
            RestoreStandardInOut();
        }
        protected void ExecuteProcess();
        protected void RestoreStandardInOut() => Console.WriteLine("IExecuteProcessActivity.RestoreStandardInOut()...");
    }

    class ExecuteProcessActivity : IExecuteProcessActivity
    {
        public ExecuteProcessActivity(string executablePath) => ExecutableName = executablePath ?? throw new ArgumentNullException(nameof(executablePath));
        public string ExecutableName { get; }
        void IExecuteProcessActivity.RedirectStandardInOut() => Console.WriteLine( "ExecuteProcessActivity.RedirectStandardInOut()...");
        void IExecuteProcessActivity.ExecuteProcess() => Console.WriteLine($"ExecuteProcessActivity.IExecuteProcessActivity.ExecuteProcess()...");
        public void Run()
        {
            ExecuteProcessActivity activity = new ExecuteProcessActivity("dotnet");
            // Składowych chronionych nie można wywoływać w klasie
            // implementującej interfejs, nawet jeśli
            // są zaimplementowane w danej klasie.
            // ((IWorkflowActivity)this).InternalRun();
            // activity.RedirectStandardInOut();
            // activity.ExecuteProcess();
            Console.WriteLine(@$"Wykonywanie niepolimorficznej metody Run() w procesie '{activity.ExecutableName}'.");
        }
    }

    public class Program
    {
        public static void Main()
        {
            ExecuteProcessActivity activity = new ExecuteProcessActivity("dotnet");
            Console.WriteLine("Wywołanie ((IExecuteProcessActivity)activity).Run()...");
            // Dane wyjściowe:
            // Wywołanie ((IExecuteProcessActivity)activity).Run()…
            // IWorkflowActivity.Start()…
            // ExecuteProcessActivity.RedirectStandardInOut()…
            // ExecuteProcessActivity.IExecuteProcessActivity.ExecuteProcess()…
            // IExecuteProcessActivity.RestoreStandardInOut()…
            // IWorkflowActivity.Stop()…
            ((IExecuteProcessActivity)activity).Run();
            // Dane wyjściowe:
            // Wywołanie activity.Run()…
            // Wykonywanie niepolimorficznej metody Run() w procesie 'dotnet'.
            Console.WriteLine();
            Console.WriteLine("Wywołanie activity.Run()...");
            activity.Run();
        }
    }
}

// Podsumowując: chronione składowe interfejsu w połączeniu z innymi modyfikatorami zapewniają kompletny mechanizm hermetyzacji, choć trzeba przyznać, że jest on skomplikowany.
