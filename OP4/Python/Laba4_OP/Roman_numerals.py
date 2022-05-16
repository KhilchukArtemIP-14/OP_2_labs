class Roman_numerals:
    def __init__(self, temp):
        if isinstance(temp,int):
            self.__romanValue = Roman_numerals.DecimalToRoman(temp)
        elif isinstance(temp,str):
            self.__romanValue = temp
        elif isinstance(temp,Roman_numerals):
            self.__romanValue = temp.__romanValue
        else:
            self.__romanValue ="I"


    @staticmethod
    def DecimalToRoman(number):
        if number >= 1000:
            return "M" + Roman_numerals.DecimalToRoman(number - 1000)
        if number >= 900:
            return "CM" + Roman_numerals.DecimalToRoman(number - 900)
        if number >= 500:
            return "D" + Roman_numerals.DecimalToRoman(number - 500)
        if number >= 400:
            return "CD" + Roman_numerals.DecimalToRoman(number - 400)
        if number >= 100:
            return "C" + Roman_numerals.DecimalToRoman(number - 100)
        if number >= 90:
            return "XC" + Roman_numerals.DecimalToRoman(number - 90)
        if number >= 50:
            return "L" + Roman_numerals.DecimalToRoman(number - 50)
        if number >= 40:
            return "XL" + Roman_numerals.DecimalToRoman(number - 40)
        if number >= 10:
            return "X" + Roman_numerals.DecimalToRoman(number - 10)
        if number >= 9:
            return "IX" + Roman_numerals.DecimalToRoman(number - 9)
        if number >= 5:
            return "V" + Roman_numerals.DecimalToRoman(number - 5)
        if number >= 4:
            return "IV" + Roman_numerals.DecimalToRoman(number - 4)
        if number >= 1:
            return "I" + Roman_numerals.DecimalToRoman(number - 1)
        return ""
    def SetRomanValue(self,myStringValue):
        self.__romanValue=myStringValue

    def SetValue(self, myIntValue):
        self.__romanValue = Roman_numerals.DecimalToRoman(myIntValue)

    def GetRomanValue(self):
        return self.__romanValue

    def GetDecimalValue(self):
        return Roman_numerals.RomanToDecimal(self.__romanValue)

    @staticmethod
    def RomanToDecimal(number):
        result=0
        last=0
        values={'I':1,'V': 5,'X': 10,'L': 50,'C': 100,'D': 500,'M': 1000}
        for i in range(len(number)-1,-1,-1):
            current=values[number[i]]
            if current<last:
                result-=current
            else:
                result+=current
            last=current
        return result
    def __iadd__(self, other):
        suma= Roman_numerals.RomanToDecimal(self.__romanValue)+Roman_numerals.RomanToDecimal(other.__romanValue)
        self.__romanValue=Roman_numerals.DecimalToRoman(suma)
        return Roman_numerals(suma)

    def __add__(self, another):
        suma = Roman_numerals.RomanToDecimal(self.__romanValue) + Roman_numerals.RomanToDecimal(another.__romanValue)
        return Roman_numerals(suma)

    def FormattedOutput(self):
        return ("{roman}({dec})".format(roman=self.GetRomanValue(),dec=self.GetDecimalValue()))

