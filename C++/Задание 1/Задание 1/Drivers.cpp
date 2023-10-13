class Drivers // Базовый класс
{
private:
    std::string surname, // Фамилия
        name, // Имя
        middle_name, // Отчество
        index; // Индекс
private:
    int experience; // Стаж
public:
    Drivers()
    {
        this->surname = "";
        this->name = "";
        this->middle_name = "";
        this->experience = 0;
        this->index = "";
    }
    Drivers(std::string surname, std::string name, std::string middle_name, int experience, std::string index)
    {
        this->surname = surname;
        this->name = name;
        this->middle_name = middle_name;
        this->experience = experience;
        this->index = index;
    }
    Drivers(std::string surname, std::string name, std::string middle_name, const char* experience, std::string index)
    {
        this->surname = surname;
        this->name = name;
        this->middle_name = middle_name;
        this->experience = atoi(experience);
        this->index = index;
    }

public:
    void set_all(std::string surname, std::string name, std::string middle_name, int experience, std::string index)
    {
        this->surname = surname;
        this->name = name;
        this->middle_name = middle_name;
        this->experience = experience;
        this->index = index;
    }

    void set_surname(std::string surname)
    {
        this->surname = surname;
    }
    void set_name(std::string name)
    {
        this->name = name;
    }
    void set_middle_name(std::string middle_name)
    {
        this->middle_name = middle_name;
    }
    void set_experience(int experience)
    {
        this->experience = experience;
    }
    void set_index(std::string index)
    {
        this->index = index;
    }

public:
    std::string get_all()
    {
        std::string s1 = this->surname + ' '
            + this->name + ' '
            + this->middle_name + ' '
            + std::to_string(this->experience) + ' '
            + this->index;
        return s1;
    }

    std::string get_surname()
    {
        std::string s1 = this->surname;
        return s1;
    }
    std::string get_name()
    {
        std::string s1 = this->name;
        return s1;
    }
    std::string get_middle_name()
    {
        std::string s1 = this->middle_name;
        return s1;
    }
    std::string get_index()
    {
        std::string s1 = this->index;
        return s1;
    }
    int get_experience()
    {
        return this->experience;
    }
};