# computer-graphics-6
## __DdaBresenham__
__сдано__

1 лабораторная - прямая линия используя алгоритмы ЦДА и Брезенхема  
____
## __Brazenham_Ellipse__
__сдано__

2 лабораторная - Нарисовать эллипс по а и б (алгоритмы Брезенхема)
![GRAF_1678516745684](https://user-images.githubusercontent.com/83748388/224469519-062e28b4-5c01-4a3a-945a-b01a61c02929.png)
____
нарисовать эллипс по заданным а и б методом брезенхема, работает для любых а, б
## 3 лабораторная - Вращать любую фигуру
организовать два режима ввода: 
* линии по точкам,
* рисование карандашом

изображение должно вращаться с помощью афинных преобразований 2д
____
## __cubeRotate__
4 лабораторная - Вращать куб

нарисовать куб в 3д пространстве, вращающийся по каждой из осей вокруг заданной пользователем точки (хyz)
____
## 5 лабораторная - Закрасить треугольник
заливка затравкой. польз рисует некоторую фигуру (контур) и алгоритм заливки должен ее закрасить
контур произвольный
____
##  __Otsechenie__
6 лабораторная 
задается прямоугольник, и список линий, заданных точками начала и конца координат (щелк мышкой), 2д; нарисовать только те части линий которые входят в прямоугольник, алгоритм отсечения
____
## __pyramidRotate__
7 лабораторная - удаление невидимых граней. 
дан правильный н-угольник, зкот лежит в основании пирамиды. закрасить каждую грань своим цветом, пирамида должна вращаться вокруг заданой точки по трем осям
и при этом надо использовать алгоритм удаления невидимых граней
чтобы не отрисовывать невидимые грани
____
## 8 лабораторная - построение гистограммы
пользователь видит перед собой окно, в котором есть кнопки, в имйдж выводится изображение, кот загружается из файла, строится гистограмма для rgb задается масштаб
в процентах
от максимума
____
## 9 лабораторная Отрисовка огня на полу:
Огонь - система частиц + Освещение (RayTracing)
Пол - разноцветные плитки, например, шахматный пол или вообще все плитки разноцветные
Рендеринг - перспективная проекция
____
## __Graphics10__
10 лабораторная Модификация изображения - Матричное преобразование изображения - Матричные фильтры изображений
Ссылки к 10-ой:
* https://en.wikipedia.org/wiki/Kernel_(image_processing)
* https://habr.com/ru/articles/142818/
  
Дополнения к 10-ой:

 Пользователь вводит:
1. Размерность матрицы n; Матрица квадратная
2. Коефицент k (float), на который умножается результат матрицы свёртки (1 / div = k: в примере Habr)
3. Сама матрица
4. Вариант обработки № 1: Брать значения пикселей только из а) исходного изображения или брать из б) редактируемого изображения (Динамически)
5. Вариант обработки № 2: Если алгоритм берёт значения из несуществующего пикселя, который находиться вне изображения, то в значение записывать: а) 0 или б) 255 (Максимальное значение пикселя)
6. Пользователь выбирает по какому каналу редактируется изображение: R, G или B
7. Загрузка\Сохранение изображений
8. Парочку (2-3) шаблонных матриц добавить в программу (Матрицу размытия и матрицу обнаружения границ, например) 

____
## __graphics13__
13 лабораторная 

как поняла достраивает грани
____
## __mal__
множество Мандельброта
__сдано__

16 лабораторная - любой фрактал на выбор