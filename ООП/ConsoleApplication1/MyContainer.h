#pragma once

template<typename T>class MyContainer
{
protected:
	T *Cont; // указатель на контейнер
	int size; // размер контейнера
	T top; // вершина контейнера
	float x, y, x1 = 0, x2 = 0, x3 = 0, y1 = 0, y2 = 0, y3 = 0, r, l, h, poluos;
	int rotation = 0, a;
public:

	MyContainer(int = 10);//по умолчанию размер=10
	virtual ~MyContainer();
	template<typename T>void operator ++(){
		AfxMessageBox(L"++");
	};//реализация итератора
	bool push(const T); // поместить элемент в контейнер
	bool pop(); // удалить из контейнера элемент
	void Show();// показать контейнер
	void Edit();//редактировать переменные, чтобы не вышли за пределы видимости
	void ChangeAngle();//изменить угол у линии
	void Resize();//поменять размер окружность
	void Rotate();//вращать эллипс, линию, ромб, четырехугольник
	void MoveTo(int charCode);//двигать фигуру
};

template<typename T>MyContainer<T>::MyContainer(int s)
{
	size = s > 0 ? s : 10;   // инициализировать размер контейнера
	Cont = new T[size]; // выделить память под контейнер
	top = -1; // значение -1 говорит о том, что контейнер пуст
	std::cout << "Good";;
};

template<typename T>MyContainer<T>::~MyContainer()
{
	delete[] Cont;
};

template <typename T>bool MyContainer<T>::push(const T Obj)
{
	if (top == size - 1)return false; // контейнер полон
	top++;
	Cont[top] = Obj; // помещаем элемент в контейнер
	return true; // успешное выполнение операции
};

template <typename T>bool MyContainer<T>::pop()
{
	if (top == -1)return false; // контейнер пуст
	Cont[top] = NULL; // удаляем элемент из контейнера
	top--;
	return true; // успешное выполнение операции
};

// вывод стека на экран
template <typename T>void MyContainer<T>::Show()
{
	for (int ix = size - 1; ix >= 0; ix--)Cont[ix];
};
