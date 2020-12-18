## Term3_Isp_lab4
#Структура
-ConfigurationManager содержит все настройки:
    +XmlJsonParser - папка с соответствующими парсерами из лаб3
    +Options - папка с классами настроек:
          +DefaultOptions - класс с настройками по умолчанию, которые могут перенастраиваться из xml или json
          +dbOptions - настройки для DataManager
          +FileActionOptions, EncoderOptions - настройки для FileManager
          +EtlXmlOptions, EtlJsonOptions - классы, которые заполняют настройками DefaultOptions используя парсеры
    +класс Manager инициирует и руководит настройками
-DataAccessLayer - работает с базой данных, ведет простейший мониторинг папки с записью изменений в файл templog.txt
    +папка Entities содержит класс Person для извлечения из базы данных информации о человеке
    +папка Interfaces содержит интерфейс IRepository
    +папка Repositories сщдержит класс PersonRepository, заполняющий список людей (500) данными из БД
-DataManager - берет настройки из xml или json (там есть поле id - от 0 до 500), обращается к XmlServices - создает 
xml файл данных о человеке с полученным id и переносит его в SourseDirectory
-FileManager - из лр3
    +папка FileAction содержит Archiver, Encoder для соответствующих действий, и FileAction мониторит SourceDirectory, при попадании туда xml - 
    шифрует его, архивирует и переносит архив в TargetDirectory, там разархивирует, дешифрует и помещает в ряд папок по дате
-ServiceLayer - посредник между DataAccessLayer и XmlServices
    +DTO содержит аналог класса Person - PersonDTO, так как не может обращаться к БД (средний уровень)
    +Interfaces содержит интерфейс IPersonService
    +Services содержит класс PersonService для нахождения человека по id из списка, который передан из DataAccessLayer
-XmlServices для создания и перемещения файла xml с данными о человеке
    +FileGenerator для создания xml файла
    +FileTransfer для перемещения в SourceDirectory
-Запросы SQL - хранит 2 запроса - написание хранимой процедуры (объединяет все необходимые поля в 1 таблицу (500 строк), сортирует по id) и ее вызов
#Запуск
-Для установки FileManager в командной строке ввести 
  C:\YCHEBA\ИСП\Lab4\FileManager\bin\Debug
  InstallUtil.exe FileManager.exe
-Для установки DataManager в командной строке ввести 
  C:\YCHEBA\ИСП\Lab4\DataManager\DataManager\bin\Debug
  InstallUtil.exe DataManager.exe
-Сначала запустить FileManager, затем DataManager в службах
-файлы с настройками xml и json лежат и тут C:\YCHEBA\ИСП\Lab4\FileManager\bin\Debug, и тут C:\YCHEBA\ИСП\Lab4\DataManager\DataManager\bin\Debug
-согласно xml и json все директории (Source, Target и для xml  файла с данными о человеке, а также templog.txt) бутут по пути C:\\Lab4\\(создается сам)
