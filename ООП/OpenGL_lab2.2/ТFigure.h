#pragma once
//абстрактный класс
class ТFigure abstract
{
protected://чтобы из производных классов были доступны
	float x, y;
public:
	ТFigure();
	ТFigure(float dx,float dy);
	virtual void Show()abstract = 0;
	virtual void Edit()abstract = 0;
	virtual void MoveTo();//т.к. функции похожи - реализуем в самом классе
	virtual ~ТFigure();
};

