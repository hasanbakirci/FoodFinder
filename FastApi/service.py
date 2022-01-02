import tensorflow as tf
import numpy as np
import os
from tensorflow.keras.models import load_model
# pip install tensorflow
# pip install opencv-python

IMG_SIZE = 224
my_classes = ["biber","mısır","portakal","domates",
"turp","patates","turp","nar",
"ananas","biber","elma","havuç",
"marul","biber","patlıcan","pancar",
"kivi","armut","lahana","karnıbahar",
"biber","limon","patates","üzüm",
"salatalık","mısır","muz","sarımsak",
"biber","karpuz","mango","bezelye",
"soğan","patates","ıspanak","bezelye"]

def predict(file):
    path = './'+file
    model = load_model('model.h5')
    img = tf.io.read_file(path)
    img = tf.io.decode_image(img, channels=3)
    img = tf.image.resize(img,[IMG_SIZE,IMG_SIZE])
    img = np.expand_dims(img, axis=0)
    
    y_pred = model.predict(img)
    print(y_pred)
    y_classes = [np.argmax(element) for element in y_pred]
    print(y_classes)
    return my_classes[y_classes[0]]