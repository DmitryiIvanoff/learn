#pragma once
//абстрактный класс
class ТFigure 
{
protected://чтобы из производных классов были доступны
	float x, y, x1 = 0, x2 = 0, x3 = 0, y1 = 0, y2 = 0, y3 = 0;
public:
	ТFigure();
	ТFigure(float dx,float dy);
	virtual void Show() = 0;
	virtual void Edit() = 0;
	virtual void ChangeAngle();
	virtual void Resize();
	virtual void Rotate();
	virtual void MoveTo(int charCode);//т.к. функции похожи - реализуем в самом классе
	virtual ~ТFigure();
};

