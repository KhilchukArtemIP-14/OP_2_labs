from osoba import Osoba
from random import randint
from datetime import date,timedelta

class Vykladach(Osoba):
    def __init__(self):
        name=input("Please, input the name of lecturer\n")
        self._disciplines = []
        self._popularityPerDiscipline = {}
        dateOfBirth=date(randint(1949,1995),randint(1,12),randint(1,30))
        Osoba.__init__(self,name,dateOfBirth)
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
            self._disciplines.append(temp)
            temp = input()

    def OutputDisciplines(self):
        print("Disciplines of {name}".format(name=self._pIB))
        for i in self._disciplines:
            print("\t-{discipline}".format(discipline=i.ljust(12)))

    def SetGrades(self):
        for i in self._disciplines:
            self._popularityPerDiscipline.setdefault(i, randint(0, 10))

    def OutputGrades(self):
        print("Grades of {name}".format(name=self._pIB))
        for i in self._disciplines:
            print("\t-{discipline}: {grade}".format(discipline=i.ljust(12), grade=self._popularityPerDiscipline[i]))

    def CalculateRating(self):
        suma = 0
        for i in self._disciplines:
            suma += self._popularityPerDiscipline[i]
        return suma / len(self._disciplines)

    def GetDisciplines(self):
        return self._disciplines

    def GetGrades(self):
        return self._popularityPerDiscipline

    def GetRating(self):
        return "{name}: {rating}".format(name=self._pIB,rating=self._rating )
    def GetName(self):
        return self._pIB