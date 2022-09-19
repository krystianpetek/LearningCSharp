using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using Zadanie_13._01.Model;

namespace Zadanie_13._01.ViewModel;

public class StudentViewModel : INotifyPropertyChanged
{
    public StudentViewModel(Student student)
    {
        if (student == null)
            return;
        Kursant = student;
        Wyczysc = new RelayCommand(o =>
        {
            var response = MessageBox.Show("Czy wyczyścic dane studenta?", "Pytanie", MessageBoxButton.YesNo,
                MessageBoxImage.Question);
            if (response != MessageBoxResult.Yes)
                return;

            Imie = string.Empty;
            Nazwisko = string.Empty;
            RokPrzyjeciaNaStudia = DateTime.Now.Year;
        },null);
    }

    public StudentViewModel() : this(new Student() { imie = "Jan", nazwisko = "Kowalski", rokPrzyjeciaNaStudia = 2014})
    { }

    private Student kursant;
    public Student Kursant
    {
        get
        {
            return kursant;
        }
        set
        {
            if (value != null)
                kursant = value;
            OnPropertyChanged(nameof(Kursant));
        }
    }

    public string Imie
    {
        get => Kursant.imie;
        set
        {
            //if (Kursant.imie == value || value.Length <= 0)
            //    return;
            Kursant.imie = value;
            OnPropertyChanged(nameof(Imie));
        }
    }

    public string Nazwisko
    {
        get => Kursant.nazwisko;
        set
        {
            //if (Kursant.nazwisko == value || value.Length <= 0)
            //    return;
            Kursant.nazwisko = value;
            OnPropertyChanged(nameof(Nazwisko));
        }
    }

    public int RokPrzyjeciaNaStudia
    {
        get => Kursant.rokPrzyjeciaNaStudia;
        set
        {
            //if (Kursant.rokPrzyjeciaNaStudia == value || value <= 1900 ||
            //    value >= DateTime.Now.Year + 1) return;

            Kursant.rokPrzyjeciaNaStudia = value;
            OnPropertyChanged(nameof(RokPrzyjeciaNaStudia));
            OnPropertyChanged(nameof(CzasStudiowania));
        }
    }

    public string CzasStudiowania => (DateTime.Now.Year - Kursant.rokPrzyjeciaNaStudia).ToString();
    
    public event PropertyChangedEventHandler? PropertyChanged;
    
    protected virtual void OnPropertyChanged(string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public RelayCommand Wyczysc { get; set; }
    
}