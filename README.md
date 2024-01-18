Cтворіть консольний застосунок «Облік клієнтів».

Умова завдання:
У перукарні працює один майстер. Він витрачає на одного клієнта рівно 20 хвилин, а потім одразу 
переходить до наступного, якщо в черзі хтось є, або чекає, коли прийде наступний клієнт.
Дано години приходу клієнтів у перукарню (у тому порядку, в якому вони приходили).
Також у кожного клієнта є характеристика, яка називається ступенем нетерпіння. Вона показує, скільки 
людина може максимально перебувати у черзі перед клієнтом, щоб вона дочекалася своєї черги та не пішла 
раніше. Якщо в момент приходу клієнта в черзі перебуває більше людей ніж ступінь його нетерпіння, він вирішує 
не чекати своєї черги та йде. Клієнт, який обслуговується в цей момент, також вважається таким, що перебуває 
в черзі.
Для кожного клієнта потрібно вказати час його виходу з перукарні.

Формат вхідного файлу:
У першому рядку вводиться натуральне число N, яке не перевищує 100 – кількість клієнтів.
У наступних N рядках вводяться години приходу клієнтів – по два числа, що позначають години та 
хвилини (години – від 0 до 23, хвилини – від 0 до 59), і ступінь їхнього нетерпіння (невід'ємне ціле число не 
більше ніж 100) – максимальна кількість осіб, яка готова чекати попереду себе у черзі. Години вказані у порядку 
зростання (усі години різні).

Гарантується, що всіх клієнтів встигнуть обслужити до півночі.
Якщо для клієнтів час закінчення обслуговування одного клієнта та час приходу іншого збігаються, 
можна вважати, що спочатку закінчується обслуговування першого клієнта, а згодом приходить другий клієнт.

Формат вихідного файлу:
У вихідний файл виведіть N пар чисел: години виходу з перукарні 1-го, 2-го, …, N-го клієнта (години та 
хвилини). Якщо на момент приходу клієнта кількість людей у черзі більша за ступінь його нетерпіння, то можна 
вважати, що час його відходу дорівнює часу приходу
