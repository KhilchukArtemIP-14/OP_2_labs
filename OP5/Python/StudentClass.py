from osoba import Osoba
from random import randint
from datetime import date,timedelta

class Student(Osoba):
    def __init__(self):
        name=input("Please, input the name of student\n")
        self._disciplinesOfLastSemestr = []
        self._gradesFromLastSemstr = {}
        dateOfBirth=date(randint(2002,2006),randint(1,12),randint(1,30))
        Osoba.__init__(self,name,dateOfBirth)
        self.__groupNumber=input("Please, input his group\n")
        print("Date of birth: {den}.{month}.{year}\n Age:{vik}".format(den=str(dateOfBirth.day).zfill(2),month=str(dateOfBirth.month).zfill(2),year=dateOfBirth.year,vik=self.GetAge()))
        self.SetDisciplines()
        self.OutputDisciplines()
        self.SetGrades()
        self.OutputGrades()
        self._rating=self.CalculateRating()


    def SetDisciplines(self):
        print("Please, input your disciplines\n To exit, enter empty string")
        temp = input()
        while (temp != ""):
            self._disciplinesOfLastSemestr.append(temp)
            temp = input()

    def OutputDisciplines(self):
        print("Disciplines of {name}".format(name=self._pIB))
        for i in self._disciplinesOfLastSemestr:
            print("\t-{discipline}".format(discipline=i.ljust(12)))

    def SetGrades(self):
        for i in self._disciplinesOfLastSemestr:
            self._gradesFromLastSemstr.setdefault(i,randint(40,101))

    def OutputGrades(self):
        print("Grades of {name}".format(name=self._pIB))
        for i in self._disciplinesOfLastSemestr:
            print("\t-{discipline}: {grade}".format(discipline=i.ljust(12),grade=self._gradesFromLastSemstr[i]))
    def CalculateRating(self):
        suma=0
        for i in self._disciplinesOfLastSemestr:
            suma+=self._gradesFromLastSemstr[i]
        return suma/len(self._disciplinesOfLastSemestr)

    def GetDisciplines(self):
        return self._disciplinesOfLastSemestr
    def GetGrades(self):
        return self._gradesFromLastSemstr
    def GetRating(self):
        return "{name}: {rating}".format(name=self._pIB,rating=self._rating )
    def GetName(self):
        return self._pIB