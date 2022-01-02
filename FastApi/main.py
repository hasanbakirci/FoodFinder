import shutil
from fastapi import FastAPI, UploadFile, File
import os
import uuid
# py -m venv env
# env\scripts\activate.bat
# source env/scripts/activate  # linux
# pip install fastapi[all] #
# pip install "uvicorn[standard]" #watch run gibi kurulum
# uvicorn main:app --reload # watch run gibi çalıstırma
# pip install python-multipart #swagger gibi adresi : # http://127.0.0.1:8000/docs#/
from service import predict

app = FastAPI()

@app.post("/")
async def root(file: UploadFile = File(...)):
    new_file_name = str(uuid.uuid4())+'.jpg'
    path = 'result_images/'+new_file_name
    with open(path,'wb') as buffer:
        shutil.copyfileobj(file.file, buffer)
        model = predict(path)
        result = {"file_name": file.filename, "result" : model }
    return result

