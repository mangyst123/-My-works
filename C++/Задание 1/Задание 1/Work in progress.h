class work_in_progress
{
private:
    routes* route;
    drivers* driver;
    string departure_date,
        return_date;
private:
    int prize,
        index;

public:work_in_progress(routes* route, drivers* driver, string departure_date, string return_date, int prize, int index)
{
    this->route = route;
    this->driver = driver;
    this->departure_date = departure_date;
    this->return_date = return_date;
    this->prize = prize;
    this->index = index;
}

public:
    void set_all(routes* route, drivers* driver, string departure_date, string return_date, int prize, int index)
    {
        this->route = route;
        this->driver = driver;
        this->departure_date = departure_date;
        this->return_date = return_date;
        this->prize = prize;
        this->index = index;
    }

    void set_route(routes* route)
    {
        this->route = route;
    }
    void set_driver(drivers* driver)
    {
        this->driver = driver;
    }
    void set_departure_date(string departure_date)
    {
        this->departure_date = departure_date;
    }
    void set_return_date(string return_date)
    {
        this->return_date = return_date;
    }
    void setprize(int prize)
    {
        this->prize = prize;
    }
    void set_index(int index)
    {
        this->index = index;
    }

public:
    string get_all()
    {
        string s1 = "������� [" + route->get_all() + "]\n"
            + "�������� [" + driver->get_all() + "]\n"
            + "���� ��������: " + departure_date + '\n'
            + "���� ��������: " + return_date + '\n'
            + "���� ��������: " + to_string(this->prize) + '\n'
            + "������: " + to_string(this->index) + '\0';
        return s1;
    }

    string get_route()
    {
        string s1 = "������� [" + route->get_all() + '\0';
        return s1;
    }
    string get_driver()
    {
        string s1 = "�������� [" + driver->get_all() + "]\n" + '\0';
        return s1;
    }
    string get_departure_date()
    {
        string s1 = "���� ��������: " + this->departure_date + '\0';
        return s1;
    }
    string get_return_date()
    {
        string s1 = "���� ��������: " + this->return_date + '\0';
        return s1;
    }
    string get_prize()
    {
        string s1 = "���� ��������: " + to_string(this->prize) + '\0';
        return s1;
    }
    string get_index()
    {
        string s1 = "������: " + to_string(this->index) + '\0';
        return s1;
    }

};