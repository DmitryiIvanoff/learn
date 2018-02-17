#pragma once
//абстрактный класс
class ТFigure 
{
protected://чтобы из производных классов были доступны
	float x, y;
public:
	ТFigure();
	ТFigure(float dx,float dy);
	virtual void Show() = 0;
	virtual void Edit() = 0;
	virtual void MoveTo();//т.к. функции похожи - реализуем в самом классе
	virtual ~ТFigure();
};

