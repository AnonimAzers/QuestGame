# QuestGame
## Установка
Для установки требуется открыть файл проекта (QuestGame.sln) и собрать проект (Собрать, не запустить!)
После сборки, переходим в папку с собранной программой и переносим в нее файл QuestData.json, который находится в папке QuestGame
Запускаем игру и радуемся!
## Особенности
Вот парочка особенностей данного проекта
1. Ну стоит отметить графический интерфейс
2. Возможность вручную менять сюжет, не открывая исходный код
### Зачем так сложно?
Ну хранение сюжета в отделном JSON-файле имеет ряд преимуществ. Вот одни из них:
1. Ну для начала мы решили отказаться от обычной конструкции if-else ради простоты кода.
2. Добавляется возможность дополнять сюжет/изменять/полностью писать свой не открывая внутренний код игры, что для будущих мододелов (коих не будет) это была бы прекрасная возможность.
3. Простота написания самого сюжета. Думаю вы сами понимаете, что квест, написанный на if-else очень сильно забивает код, из-за чего можно запутаться и скорость разработки значительно упадет.
4. Возможность разделять обязанности между командой. Пока кто-то разрабатывает код, другие же могут писать сценарий, никак не вторгаясь и не мешая разработке.
## О чем игра?
Игра о трудной жизни парня, которого уволили с работы, из-за чего его жена ушла к другому. У игрока есть множество выборов и концовок. Он может просто сидеть и ничего не делать или двигаться на путь восстановления. Все зависит от игрока.
Сюжет прост, но не суть. Все прекрасно работает. Мы показали этой Демо-версией сюжета, как можно его менять самостоятельно) Развлекайтесь
## Интерфейс
Интерфейс выглядить подобным образом:

![Screenshot](https://i.imgur.com/zbAxQCB.png)
## FAQ
1. Почему WPF?
> WPF является достаточно мощным фреймворком, позволяющим красиво и качественно "рисовать" интерфейс программы.
2. Почему не в консоли?
> Ради красоты :) Как я говорил, мы обожаем доводить все до идеала.
3. Не жалко ли потраченного времени?
> Ответ: нет, не жалко. Нам нравится программировать, эта работа просто воплощение всех наших фантазий и умений, которые мы накопили за первый год обучения.
4. Как устроена система квестов?
> Обычные графы (спасибо курсовая за то, что я изучил структуры данных). Вершина - определенный этап, от которого исходят ребра к другим вершинам (соседним этапам). Прекрасно позволяет нам объеденять какие-то эпизоды между собой.
5. Сколько потребовалось времени?
> На разработку программной части часа 3. На сюжет потратили еще часика 2.
