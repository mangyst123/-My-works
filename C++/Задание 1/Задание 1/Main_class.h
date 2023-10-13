#pragma once
#include "General.h" // Подклучаю General класс
using namespace std;
using namespace tinyxml2;
class Main_class // Объявление класса
{
private:
    General<Routes> r;
    General<Drivers> dr;
    General<Work_in_progress> works;

    string path_of_the_old_file,
        path_of_the_new_file;
public:
    // При создании объекта класса Main_class автоматически считывает файл дефолтный или тот который задаст пользователь
    Main_class()
    {
        cout << "Vvedite put fila dlia chtenia:" << endl;
        string s1;
        cin >> s1;
        s1 += ".xml";
        this->path_of_the_new_file = "New.xml";
        this->r = r.read_file_Routes(s1);
        this->dr = dr.read_file_Drivers(s1);
        this->works = works.read_file_Work(s1);
    }
    Main_class(string name)
    {
        this->path_of_the_old_file = name;
        this->path_of_the_new_file = "New.xml";
        this->r = r.read_file_Routes(path_of_the_old_file);
        this->dr = dr.read_file_Drivers(path_of_the_old_file);
        this->works = works.read_file_Work(path_of_the_old_file);
    }
    Main_class(string name_old, string name_new)
    {
        this->path_of_the_old_file = name_old;
        this->path_of_the_new_file = name_new;
        this->r = r.read_file_Routes(path_of_the_old_file);
        this->dr = dr.read_file_Drivers(path_of_the_old_file);
        this->works = works.read_file_Work(path_of_the_old_file);
    }
public:
    bool del_routes(string rc, General<Routes> rt, General<Work_in_progress> wr)
    {
        Work_in_progress value;
        list<string> list_ = wr.get_codes();
        for (auto iter = list_.begin(); iter != list_.end(); iter++)
        {
            cout << *iter << endl;
            value = wr.findByCode(*iter);
            if (value.get_route_code() == rc)
            {
                cout << "Not Del" << endl;
                return false;
            }
        }
        rt.delete_object_by_code(rc);
        return true;
    }
    bool del_drivers(string rc, General<Drivers> dr, General<Work_in_progress> wr)
    {
        Work_in_progress value;
        list<string> list_ = wr.get_codes();
        for (auto iter = list_.begin(); iter != list_.end(); iter++)
        {
            cout << *iter << endl;
            value = wr.findByCode(*iter);
            if (value.get_route_code() == rc)
            {
                cout << "Not Del" << endl;
                return false;
            }
        }
        dr.delete_object_by_code(rc);
        return true;
    }
public:
    General<Routes> return_the_Roads_list()
    {
        return this->r;
    }
    General<Drivers> return_the_Drivers_list()
    {
        return this->dr;
    }
    General<Work_in_progress> return_the_Work_in_progress_list()
    {
        return this->works;
    }
public:
    void add_route(Routes& rout)
    {
        this->r.push_back(rout);
    }
    void new_route(string name, int range, int amount_of_days, int payment)
    {
        Routes rout(name, range, amount_of_days, payment, this->r.get_new_cod());
        this->add_route(rout);
    }
    Routes find_route_by_index(string index)
    {
        return r.findByCode(index);
    }
    void add_driver(Drivers& driver)
    {
        this->dr.push_back(driver);
    }
    Drivers find_driver_by_index(string index)
    {
        return dr.findByCode(index);
    }
    // Деструктор, при завершении работы программы автоматически выписывает данные из списка в файл
    ~Main_class()
    {
        this->r.write_everything_to_file(this->r, dr, works, path_of_the_new_file);
    }
};
