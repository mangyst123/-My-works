class Routes  // Объявление класса (Базовый класс)
{
    // Атрибуты класса не должны находиться в прямом доступе 
    // для пользователя поэтому используеться модификатор доступа private 
private:
    std::string path_name, // Имя пути
        index; // Индекс
private:
    int range, // Растояние
        amount_of_days, // Количество дней в пути
        payment; // Оплата
public:
    // Конструктор класса, если был создан пустой объект (для дальнейшей записи в него данных)
    Routes()
    {
        this->path_name = "";
        this->range = 0;
        this->amount_of_days = 0;
        this->payment = 0;
        this->index = "";
    }
    // Конструктор который вызываеться при создании объекта с данными
    Routes(std::string name, int range, int amount_of_days, int payment, std::string index)
    {
        this->path_name = name;
        this->range = range;
        this->amount_of_days = amount_of_days;
        this->payment = payment;
        this->index = index;
    }
    // Конструктор для заполнения из базы данных (будет использоваться в Задании 2)
    Routes(const char* name, const char* range, const char* amount_of_days, const char* payment, const char* index)
    {
        this->path_name = name;
        this->range = atoi(range);
        this->amount_of_days = atoi(amount_of_days);
        this->payment = atoi(payment);
        this->index = index;
    }
    // Методы класса 
public:
    // Если не ввели данные обьекта класса, то этот метод позволяет их заполнить
    void set_all(std::string name, int range, int amount_of_days, int payment, std::string index)
    {
        this->path_name = name;
        this->range = range;
        this->amount_of_days = amount_of_days;
        this->payment = payment;
        this->index = index;
    }
    // Следующие 5 методов вводять отдельно каждый атрибут
    void set_path_name(std::string name)
    {
        this->path_name = name;
    }
    void set_range(int range)
    {
        this->range = range;
    }
    void set_amount_of_days(int amount)
    {
        this->amount_of_days = amount;
    }
    void set_index(std::string index)
    {
        this->index = index;
    }
    void set_payment(int payment)
    {
        this->payment = payment;
    }
public:
    // Этот метод возвращает атрибуты записанные через символ ' '
    std::string get_all()
    {
        std::string s1 = this->path_name + ' '
            + std::to_string(this->range) + ' '
            + std::to_string(this->amount_of_days) + ' '
            + std::to_string(this->payment) + ' '
            + this->index;
        return s1;
    }
    // Следующие 5 методов позволяют отдельно вывести каждый атребут
    std::string get_path_name()
    {
        return this->path_name;
    }
    std::string get_index()
    {
        return this->index;
    }
    int get_range()
    {
        return this->range;
    }
    int get_amount_of_days()
    {
        return this->amount_of_days;
    }
    int get_payment()
    {
        return this->payment;
    }
public:
    // Перегрузка оператора = (необходимо что бы присваивать атрибуты одного объекта класса, другому объекту)
    void operator =(Routes new_rout)
    {
        this->path_name = new_rout.path_name;
        this->range = new_rout.range;
        this->amount_of_days = new_rout.amount_of_days;
        this->payment = new_rout.payment;
        this->index = new_rout.index;
    }
};