# Logging

## Formating
* `%(asctime)s`: Human readable date format
* `%(file)s`: Human readable date format

```python
import logging



fmtstr = "%(asctime)s:%(levelname)s:%(funcName)s Line:%(lineno)d %(message)s"
datestr = "%m/%d/%Y %I:%M:%S %p"
logging.basicConfig(level=logging.DEBUG,
		filename="output.log",
		filemode="w",
		format=fmtstr,
		datefmt=datestr)

def anotherFunc():
	logging.debug("I'M FUCKING WATCHING")

logging.debug("Debug")
logging.info("info")
logging.warning("warning")
logging.error("error")
logging.critical("critical")


logging.info("HERE IS A FUCKING STRING AND A FUCKING NUMBER")
logging.warning("PEOPLE ARE GOING TO FUCKING DIE")

anotherFunc()


```



