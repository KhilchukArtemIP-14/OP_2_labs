from Roman_numerals import Roman_numerals
import random

def ShowNumeralsBeforeOperations(R1, R2, R3):
    print("First numeral:\n", R1.FormattedOutput())
    print("Second numeral:\n", R2.FormattedOutput())
    print("Third numeral:\n", R3.FormattedOutput())

def ShowNumeralsAfterOperations(R1,R2,R3,temp):
    print("(++R1)= ++{roman}:\n{result}\n".format(roman=Roman_numerals(R1.GetDecimalValue()-1).FormattedOutput(),result=R1.FormattedOutput()))
    print(("(R2+={tempNum})= {R2before} + {tempInRoman}:\n{result}\n".format(tempNum=temp,R2before=Roman_numerals(R2.GetDecimalValue()-temp).FormattedOutput(),tempInRoman=Roman_numerals(temp).FormattedOutput(),result=R2.FormattedOutput())))
    print(("R3= R1 + R2= {Roman1} + {Roman2}:\n{result}\n".format(Roman1=R1.FormattedOutput(),Roman2=R2.FormattedOutput(),result=R3.FormattedOutput())))

if __name__ == "__main__":
    R1 = Roman_numerals(random.randint(0,19))
    R2 = Roman_numerals("X")
    R3 = Roman_numerals(R2)
    ShowNumeralsBeforeOperations(R1, R2, R3)
    R1+=Roman_numerals(1)
    increment=int(input("Please, input the value, that R2 would incremented with\n"))
    R2+=Roman_numerals(increment)
    R3=R1+R2
    print("Values after incrementation")
    ShowNumeralsAfterOperations(R1,R2,R3,increment)
    print("And so, N3 is:",R3.GetDecimalValue())