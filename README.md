---
abstract: |
  Ce document est le guide d'utilisation de notre serious game. Ce jeu
  de Réalité Virtuelle est destiné à un usage médical et a été conçu
  pour aider à la rééducation de personnes atteintes de troubles
  cognitifs.
author:
- Cazuc Ewen, Chmura Marianne, Derrien Thomas, Ressy Adrienne
date: 2022-2023
title: "**Guide d'Utilisation**"
---

# Introduction

Vous pouvez jouer en position assise ou debout, mais afin de vous
assurer une meilleure expérience de jeu nous vous conseillons de jouer
debout. La partie Jouer est destinée aux patients ou plus globalement
aux joueurs et la partie Récupération des données est destinée à
l'équipe soignante.

# Matériel nécessaire

Pour jouer vous aurez besoin d'un casque Meta Quest 2, d'une paire de
Manettes Meta Quest 2 Touch et d'un ordinateur pouvant supporter des
jeux de Réalité Virtuelle. Vous avez également besoin d'une pièce avec
suffisament d'espace pour être libre de vos mouvements au minimum en
restant sur place.

# Logiciel nécessaire

Pour jouer à ce jeu vous aurez besoin des l'applications Oculus et Unity
Hub. La première servant à connecter le casque de Réalité Virtuelle et
la seconde à lancer le jeu.

# Jouer

## Lancer le jeu

### Lancer Oculus

Lancez l'application Oculus sur votre ordinateur et connectez votre
casque à l'ordinateur.

### Lancer Unity 3D

Lancez l'application Unity 3D et ouvrez le projet. Ensuite, appuyez sur
le bouton play et mettez votre casque.

## Déplacements

### Sans les manettes

Vous pouvez vous mouvoir dans le jeu comme vous le feriez dans la
réalité.

### Avec les manettes

Vous pouvez tourner sur vous même dans le sens horaire et anti-horaire
en poussant respectivement le stick analogique de chaque manette vers la
gauche et vers la droite.

Vous pouvez vous déplacer en utilisant la téléportation. Pour cela,
pointer le sol la où vous voulez vous téléporter, un pointeur blanc
apparaitera. Ensuite, pressez le Bouton de grip.

## Interagir

### Canvas

Pour interagir avec un canva, vous pouvez poiter le rayon de l'une de
vos mains vers l'endroit où vous voulez interagir. Quand le rayon
devient blanc vous pouvez presser la Gâchette pour interagir.

### Objets

Pour saisir un objet, vous pouvez pointer le rayon de l'une de vos mains
vers celui-ci. Quand le rayon devient blanc vous pouvez presser le
Bouton de grip pour interagir. L'objet sera alors dans votre main tant
que vous maintenez le Bouton de grip. Pour relacher l'objet, relacher le
Bouton de grip.

# Récuperation des données

### Prérequis

Assurez-vous d'avoir Python3 d'installé. Si ce n'est pas le cas, rendez
vous sur « https://www.python.org/downloads/ »

### Lecture des données 

Pour la visualisation des données, il faut commencer par lancer
App.py.Le fichier se trouve dans le dossier \"App Patient\". Une fois
l'application lancée, ouvrez un navigateur web et tapez «
http://127.0.0.1:5000» dans la barre de recherche.

Ensuite, sélectionnez le fichier représentant la base de données, puis
cliquez sur « Analyser le fichier ».

Vous serez automatiquement redirigé vers une page listant l'ensemble des
patients de la base de données.

Pour visualiser les parties d'un patient, cliquez sur son nom.

# Conclusion

Ce document permet aux de notre application de Réalité Virtuelle ainsi
que de l'application Web pour la visualisation des données de pouvoir le
faire plus facilement.
