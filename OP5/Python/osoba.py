from datetime import date
from abc import ABC,abstractmethod


class Osoba(ABC):
    def __init__(self,name,dOB):
        self._pIB=name
        self._dateOfBirth=dOB

    @abstractmethod
    def CalculateRating(self):
        pass
    def ReturnName(self):
        return self._pIB
    def GetDateOfBirth(self):
        return self._dateOfBirth
    def GetAge(self):
        return (date.today()-self._dateOfBirth).days//365


