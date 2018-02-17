#pragma once
#include "ТFigure.h"
#include "Circle.h"
#include "Line.h"
#include "Ellipsoid.h"
#include "Quadrangle.h"
#include "Rhombus.h"

struct Node       //Структура являющаяся звеном списка
{
	ТFigure* x;     //Значение x будет передаваться в список
	Node *Next, *Prev; //Указатели на адреса следующего и предыдущего элементов списка
};

class MyContainer   //Создаем тип данных Список
{
	Node *Head, *Tail; //Указатели на адреса начала списка и его конца
	int length = 0;
public:
	MyContainer() :Head(NULL), Tail(NULL),length(0){}; //Инициализируем адреса как пустые
	~MyContainer(); //Деструктор
	void Give(char ch,int code); //Функция отображения списка на экране
	void OnChangeradius();//смена радиуса
	void Add(ТFigure* x); //Функция добавления элементов в список
	int Length(); //Выводит длину массива
};

void MyContainer::OnChangeradius(){

}

MyContainer::~MyContainer() //Деструктор
{
	while (Head) //Пока по адресу на начало списка что-то есть
	{
		Tail = Head->Next; //Резервная копия адреса следующего звена списка
		delete Head; //Очистка памяти от первого звена
		Head = Tail; //Смена адреса начала на адрес следующего элемента
	}
}

int MyContainer::Length(){//длина массива
	return length;
}

void MyContainer::Add(ТFigure* x)
{
	length += 1;
	Node *temp = new Node; //Выделение памяти под новый элемент структуры
	temp->Next = NULL;  //Указываем, что изначально по следующему адресу пусто
	temp->x = x;//Записываем значение в структуру

	if (Head != NULL) //Если список не пуст
	{
		temp->Prev = Tail; //Указываем адрес на предыдущий элемент в соотв. поле
		Tail->Next = temp; //Указываем адрес следующего за хвостом элемента
		Tail = temp; //Меняем адрес хвоста
	}
	else //Если список пустой
	{
		temp->Prev = NULL; //Предыдущий элемент указывает в пустоту
		Head = Tail = temp; //Голова=Хвост=тот элемент, что сейчас добавили
	}
}

void MyContainer::Give(char ch,int code)
{
	Node *temp = Tail;//Временный указатель на адрес последнего элемента
	switch (ch)
	{
	case 's':{//показываем фигуры
		//ВЫВОДИМ СПИСОК С НАЧАЛА
		temp = Head; //Временно указываем на адрес первого элемента
		while (temp != NULL) //Пока не встретим пустое значение
		{
			temp->x->Show(); //Выводим фигуру на экран
			temp = temp->Next; //Смена адреса на адрес следующего элемента
		}
	}; break;
	case 'm':{//двигаем по ивентам
				 //ВЫВОДИМ СПИСОК С НАЧАЛА
				 temp = Head; //Временно указываем на адрес первого элемента
				 while (temp != NULL) //Пока не встретим пустое значение
				 {
					 temp->x->MoveTo(code); //Выводим фигуру на экран
					 temp = temp->Next; //Смена адреса на адрес следующего элемента
				 }
	}; break;
	case 'r':{//ресайз круга
				 temp = Head; //Временно указываем на адрес первого элемента
				 while (temp != NULL) //Пока не встретим пустое значение
				 {
					 if (dynamic_cast<Circle*>(temp->x)){
						 temp->x->Resize();
					 }
					 temp = temp->Next; //Смена адреса на адрес следующего элемента
				 }
	}; break;
	case 't':{//смена угла- вращение
				 temp = Head; //Временно указываем на адрес первого элемента
				 while (temp != NULL) //Пока не встретим пустое значение
				 {
					 if (dynamic_cast<Line *>(temp->x)){
						 temp->x->ChangeAngle();
					 }
					 if (dynamic_cast<Ellipsoid *>(temp->x) || dynamic_cast<Quadrangle *>(temp->x) || dynamic_cast<Rhombus *>(temp->x)){
						 temp->x->Rotate();
					 }
					 temp = temp->Next; //Смена адреса на адрес следующего элемента
				 }
	}; break;
	case 'e':{//двигаем эллипс
				 temp = Head; //Временно указываем на адрес первого элемента
				 while (temp != NULL) //Пока не встретим пустое значение
				 {
					 //37 - left; 38 -up;39- right;40-down
					 int flag = 37 + rand() / (RAND_MAX / 3);
					 if (dynamic_cast<Ellipsoid *>(temp->x)){
						 temp->x->MoveTo(flag);
					 }
					 temp = temp->Next; //Смена адреса на адрес следующего элемента
				 }
	}; break;
	case 'q':{//двигаем четырехугольник
				 temp = Head; //Временно указываем на адрес первого элемента
				 while (temp != NULL) //Пока не встретим пустое значение
				 {
					 //37 - left; 38 -up;39- right;40-down
					 int flag = 37 + rand() / (RAND_MAX / 3);
					 if (dynamic_cast<Quadrangle *>(temp->x)){
						 temp->x->MoveTo(flag);
					 }
					 temp = temp->Next; //Смена адреса на адрес следующего элемента
				 }
	}; break;
	case 'o':{//move ромб
				 temp = Head; //Временно указываем на адрес первого элемента
				 while (temp != NULL) //Пока не встретим пустое значение
				 {
					 //37 - left; 38 -up;39- right;40-down
					 int flag = 37 + rand() / (RAND_MAX / 3);
					 if (dynamic_cast<Rhombus *>(temp->x)){
						 temp->x->MoveTo(flag);
					 }
					 temp = temp->Next; //Смена адреса на адрес следующего элемента
				 }
	}; break;
	case 'l':{//move line
				 temp = Head; //Временно указываем на адрес первого элемента
				 while (temp != NULL) //Пока не встретим пустое значение
				 {
					 //37 - left; 38 -up;39- right;40-down
					 int flag = 37 + rand() / (RAND_MAX / 3);
					 if (dynamic_cast<Line *>(temp->x)){
						 temp->x->MoveTo(flag);
					 }
					 temp = temp->Next; //Смена адреса на адрес следующего элемента
				 }
	}; break;
	case 'd':{//move ring
				 temp = Head; //Временно указываем на адрес первого элемента
				 while (temp != NULL) //Пока не встретим пустое значение
				 {
					 //37 - left; 38 -up;39- right;40-down
					 int flag = 37 + rand() / (RAND_MAX / 3);
					 if (dynamic_cast<Circle *>(temp->x)){
						 temp->x->MoveTo(flag);
					 }
					 temp = temp->Next; //Смена адреса на адрес следующего элемента
				 }
	}; break;
	default:
		break;
	}
}
