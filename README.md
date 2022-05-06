<a id="Start"></a>
# Adventure in the Dungeon
---
#### Первый опыт более плотного взаимодействия с Unity и с языком программирования C#. Данный проект является прототипом, основная цель которого изучить возможности движка Unity и написания игровой логики. Прототип разработан под платформу Android.
#### Модельки персонажей, ящиков взяты из Assetstore, остальные модельки разработаны самостоятельно. 
---

__1. ОПИСАНИЕ ИГРОВОГО ПРОЦЕССА__

Игроку необходимо перебраться на другую сторону комнаты. Там есть дверь, которая является финальной дверью для прохождения уровня. Однако не всё так просто. Дверь откроется толко если у игрока есть 3 необходимых ключа и 20 монет. Соответственно игроку предстоит отправиться на поиски всего необходимого. В комнате есть несколько движущихся платформ, которые могут доставить игрока на этаж выше или ниже. Так же в комнате в некоторых местах расположены вражеские персонажи, которые будут пытаться мешать игроку в его поисках. В комнате игроку будут встречаться деревянные ящики, которые скрывают в себе что-то интересное. Их можно разбить. В ящиках может попасться либо дополнительная монетка либо дополнитео=льная жизнь для игрока. Собрав всё неоходимое можно вернуться к двери и открыть её. Уровень завершен!

__2. ИГРОВОЙ ПРОЦЕСС__

На экране можно видеть некоторые необходимые игровому процессу элементы:

![ScreenWithText](https://user-images.githubusercontent.com/47788812/167168476-c84737cc-ecb8-4b58-9b58-82ddc701d5ef.PNG)

Текущее количество монет отображается в левом верхнем углу экрана. Справа же текущее количество жизней. Сверху посередине в красном прямоугольнике будут отображаться подобранные игроком ключи. Всего их в игре 3. Внизу справа и слева будут находиться элементы управления персонажем. Камера же всегда размещена сбоку и будет следовать за игроком. В прямоугольнике внизу посередине экрана будет отображаться текст, который дасть небольшую подсказку игроку.

![ScreenWithText2](https://user-images.githubusercontent.com/47788812/167169010-400e9392-1c80-46c1-95bc-a6f99cad3b89.PNG)

Игровые элементы в виде ящиков распологаются в разных уровнях комнаты. Разбив их можно получить допольнительные монеты или жизни. 
Вражеские персонажи перемещаются в пределах своей платформы вперед из назад. На игрока они реагируют в случае его приближения на определенную дистанцию. Тогда они поворачиваются в сторону игрока, и когда игрок на одном уровне с ними, начинают атаковать игрока. Игрок и вражеские персонажи могут бросаться шариками. 
Платформы распологаются в разных местах комнаты и двигаются в отведенном им направлении. Направление может быть вверх-вниз или вправо-влево. Благодаря платформам можно перемещаться на разные этажи комнаты. Падение с высоты наносит игроку урон. По этому стоит пользоваться платформами.

![ScreenWithText3](https://user-images.githubusercontent.com/47788812/167169891-40d077ff-1be8-4754-a9fb-3ffbc7e3696e.PNG)

Финальная дверь имеет в себе триггер, который выведет игроку текст внизу экрана в зависимости от момента, когда подошел игрок. Если игрок еще не собрал необходимое количество предметов, текст подскажет сколько еще нужно собрать. Если игрок уже собрал необходимое количество предметов, текст скажет игроку, что всё необходимое собрано и можно пройти. В таком случае кнопка выстрела в триггере двери перестанет бросать шарики, а станет отвечать за открытие двери. 
Уровень пройден!

__3. КРАТКОЕ ПРИМЕЧАНИЕ__

Данный проект собран и размещен как прототип на платформе itch.io для удобства его просмотра. Работа над проектом помогла лучше понять редактор Unity, построение игровой логики, возможности экспорта проекта и импорта в проект моделей, работу с интерфейсом и мобильным управлением. Данный проект является первым проектом, здесь не использовалось сложных элементов, паттернов программирования. Однако проект завершен и демонстрирует в первую очередь с чего начинал его разработчик. 

Ссылка на страницу игры [тут](https://aleksandrshatokhin.itch.io/adventure-in-the-dungeon).

[К началу](#Start)