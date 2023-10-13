#include "Library.h"
#include "Work in progress.h"
template<typename T>
class General
{
private:
	std::list<T> object;

public:
	General()
	{
		this->object = {};
	}
	General(std::list<T> l)
	{
		this->object = l;
	}
public:
	T findByCode(std::string code)
	{
		// auto - обозначает list<int>::iterator 
		for (auto iter = object.begin(); iter != object.end(); iter++)
			if ((*iter).get_index() == code)
				return *iter;
	}
public:
	void push_back(T data)
	{
		object.push_back(data);
	}
	void delete_object_by_code(std::string code)
	{
		for (auto iter = object.begin(); iter != object.end(); iter++)
			if ((*iter).get_index() == code)
			{
				object.erase(iter);
				break;
			}

	}
	void delete_all()
	{
		object.clear();
	}

public:
	std::string get_all_cod()
	{
		std::string S = "";
		for (auto iter = object.begin(); iter != object.end(); iter++)
			S += (*iter).get_index() + ' ';
		return S;
	}
	std::list<std::string> get_codes()
	{
		std::list<std::string> codes;
		for (auto iter = object.begin(); iter != object.end(); iter++)
			codes.push_back((*iter).get_index());
		return codes;
	}
	std::string get_new_cod()
	{
		int code = 0;
		for (auto iter = object.begin(); iter != object.end(); iter++)
			if (std::stoi((*iter).get_index()) > code)
				code = std::stoi((*iter).get_index());

		return std::to_string(code + 1);
	}

public:
	int lenght()
	{
		int count = 0;
		for (auto iter = object.begin(); iter != object.end(); iter++)
			count++;
		return count;
	}

	General<Routes> read_file_Routes(std::string name1)
	{
		tinyxml2::XMLDocument doc;
		const char* name = name1.c_str();
		doc.LoadFile(name);
		tinyxml2::XMLHandle docHandle(&doc);
		tinyxml2::XMLElement* library = docHandle.FirstChildElement("library").ToElement();
		if (library)
		{
			General<Routes> new_list_rout = {};
			for (tinyxml2::XMLNode* node = library->FirstChildElement(); node; node = node->NextSibling())
			{
				tinyxml2::XMLElement
					* e1 = node->ToElement(),
					* e2 = e1->ToElement(),
					* e3 = e2->ToElement(),
					* e4 = e3->ToElement(),
					* e5 = e4->ToElement();

				const char
					* path_name = e1->Attribute("path_name"),
					* range = e2->Attribute("range"),
					* amount_of_days = e3->Attribute("amount_of_days"),
					* payment = e4->Attribute("payment"),
					* index = e5->Attribute("index");

				if (path_name && range && amount_of_days && payment && index)
				{

					Routes new_(path_name, range, amount_of_days, payment, index);
					new_list_rout.push_back(new_);
				}
			}
			return new_list_rout;
		}
	}
	General<Drivers> read_file_Drivers(std::string name1)
	{
		tinyxml2::XMLDocument doc;
		const char* name = name1.c_str();
		doc.LoadFile(name);
		tinyxml2::XMLHandle docHandle(&doc);
		tinyxml2::XMLElement* library = docHandle.FirstChildElement("library").ToElement();
		if (library)
		{
			General<Drivers> new_list;
			for (tinyxml2::XMLNode* node = library->FirstChildElement(); node; node = node->NextSibling())
			{
				tinyxml2::XMLElement
					* e1 = node->ToElement(),
					* e2 = e1->ToElement(),
					* e3 = e2->ToElement(),
					* e4 = e3->ToElement(),
					* e5 = e4->ToElement();

				const char
					* surname = e1->Attribute("surname"),
					* name = e2->Attribute("name"),
					* middle_name = e3->Attribute("middle_name"),
					* expirience = e4->Attribute("expirience"),
					* index = e5->Attribute("index");

				if (surname && name && middle_name && expirience && index)
				{
					Drivers new_(surname, name, middle_name, expirience, index);
					new_list.push_back(new_);
				}
			}
			return new_list;
		}
	}
	General<Work_in_progress> read_file_Work(std::string name1)
	{
		tinyxml2::XMLDocument doc;
		const char* name = name1.c_str();
		doc.LoadFile(name);
		tinyxml2::XMLHandle docHandle(&doc);
		tinyxml2::XMLElement* library = docHandle.FirstChildElement("library").ToElement();
		if (library)
		{
			General<Routes> new_list_rout = read_file_Routes(name1);
			General<Drivers> new_list_driver = read_file_Drivers(name1);
			General<Work_in_progress> new_list;
			Work_in_progress new_;
			for (tinyxml2::XMLNode* node = library->FirstChildElement(); node; node = node->NextSibling())
			{

				tinyxml2::XMLElement
					* e1 = node->ToElement(),
					* e2 = e1->ToElement(),
					* e3 = e2->ToElement(),
					* e4 = e3->ToElement(),
					* e5 = e4->ToElement(),
					* e6 = e5->ToElement();

				const char
					* departure_date = e1->Attribute("departure_date"),
					* return_date = e2->Attribute("return_date"),
					* prize = e3->Attribute("prize"),
					* indexW = e4->Attribute("index"),
					* Routes_index = e5->Attribute("Routes"),
					* Drivers_index = e6->Attribute("Drivers");

				if (departure_date && return_date && prize && indexW && Routes_index && Drivers_index)
				{

					Routes* N1 = new Routes;
					*N1 = new_list_rout.findByCode(Routes_index);
					Drivers* N2 = new Drivers;
					*N2 = new_list_driver.findByCode(Drivers_index);

					new_.set_all(N1, N2, departure_date, return_date, atoi(prize), indexW);
					new_list.push_back(new_);
				}
			}
			return new_list;
		}
	}
public:
	void write_everything_to_file(General<Routes> rout, General<Drivers> driver, General<Work_in_progress> work, std::string name1)
	{
		const char* name = name1.c_str();
		// Прописывает в начале нового файла (<?xml version="1.0" encoding="UTF-8"?>)
		tinyxml2::XMLDocument doc;
		tinyxml2::XMLDeclaration* decl = doc.NewDeclaration();
		doc.InsertEndChild(decl);
		tinyxml2::XMLElement* library = doc.NewElement("library");
		doc.InsertFirstChild(library);
		for (int i = 1, x = 1; i <= rout.lenght(); i++)
		{
			x = i;
			Routes rout_by_cod = rout.findByCode(std::to_string(i));
			tinyxml2::XMLElement* Routes = doc.NewElement("Routes");

			while (rout_by_cod.get_index() == "")
			{
				rout_by_cod = rout.findByCode(std::to_string(x));
				x++;
			}
			i = x;

			std::string name = rout_by_cod.get_path_name();
			std::string index = rout_by_cod.get_index();

			const char* na = name.c_str();
			const char* in = index.c_str();

			Routes->SetAttribute("path_name", na);
			Routes->SetAttribute("range", rout_by_cod.get_range());
			Routes->SetAttribute("amount_of_days", rout_by_cod.get_amount_of_days());
			Routes->SetAttribute("payment", rout_by_cod.get_payment());
			Routes->SetAttribute("index", in);
			library->InsertEndChild(Routes);
		}
		for (int i = 1, x = 1; i <= driver.lenght(); i++)
		{
			x = i;
			Drivers driver_by_cod = driver.findByCode(std::to_string(i));
			tinyxml2::XMLElement* Drivers = doc.NewElement("Drivers");
			while (driver_by_cod.get_index() == "")
			{
				x++;
				driver_by_cod = driver.findByCode(std::to_string(x));
			}
			i = x;

			std::string surname = driver_by_cod.get_surname();
			std::string name = driver_by_cod.get_name();
			std::string middle_name = driver_by_cod.get_middle_name();
			std::string index = driver_by_cod.get_index();

			const char* sur = surname.c_str();
			const char* nam = name.c_str();
			const char* mid = middle_name.c_str();
			const char* ind = index.c_str();

			Drivers->SetAttribute("surname", sur);
			Drivers->SetAttribute("name", nam);
			Drivers->SetAttribute("middle_name", mid);
			Drivers->SetAttribute("expirience", driver_by_cod.get_experience());
			Drivers->SetAttribute("index", ind);
			library->InsertEndChild(Drivers);
		}
		for (int i = 1, x = 1; i <= work.lenght(); i++)
		{
			x = i;
			Work_in_progress work_by_cod = work.findByCode(std::to_string(x));
			tinyxml2::XMLElement* Work_in_progress = doc.NewElement("Work_in_progress");
			while (work_by_cod.get_index() == "")
			{
				x++;
				work_by_cod = work.findByCode(std::to_string(x));
			}
			i = x;

			std::string departure_date = work_by_cod.get_departure_date();
			std::string return_date = work_by_cod.get_return_date();
			std::string prize = work_by_cod.get_prize();
			std::string index = work_by_cod.get_index();
			std::string Routes = work_by_cod.get_route_code();
			std::string Drivers = work_by_cod.get_driver_code();

			const char* dep = departure_date.c_str();
			const char* ret = return_date.c_str();
			const char* pri = prize.c_str();
			const char* ind = index.c_str();
			const char* Rou = Routes.c_str();
			const char* Dri = Drivers.c_str();

			Work_in_progress->SetAttribute("departure_date", dep);
			Work_in_progress->SetAttribute("return_date", ret);
			Work_in_progress->SetAttribute("prize", pri);
			Work_in_progress->SetAttribute("index", ind);
			Work_in_progress->SetAttribute("Routes", Rou);
			Work_in_progress->SetAttribute("Drivers", Dri);

			library->InsertEndChild(Work_in_progress);
		}
		doc.SaveFile(name);
	}

public:
	~General()
	{
		object.clear();
	}
};