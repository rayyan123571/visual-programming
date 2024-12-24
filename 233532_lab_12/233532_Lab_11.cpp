                     // Student Assgnment Sysytem

#include <iostream>
#include <string>
#include <sstream>
#include <limits.h>
using namespace std;


   // Task 01:
   //Sample Code of class Nodes :

class Node {
public:
    int key;
    string name;
    string comment;
    Node* leftChild;
    Node* rightChild;

    Node(int key, string name, string comment) {
        this->key = key;
        this->name = name;
        this->comment = comment;
        leftChild = NULL;
        rightChild = NULL;
    }

    string toString() {
        stringstream ss;
       // ss << name << " has Achieved " << key << " Marks. Comment: " << comment;
       ss<<name<<":";
       ss<<endl;
       ss<<"Marks : "<<key;
       ss<<endl;
       ss<<"Remarks : "<<comment;
        return ss.str();
    }
};

// BST class
class BST {
public:
    Node* root;

    BST() {
        root = NULL;
    }
    
    
   // Task 02:
   //BST Insertion:
   
   
    Node* insert(Node* node, int key, string name, string comment) {
        if (node == NULL)
            return new Node(key, name, comment);
        if (key < node->key)
            node->leftChild = insert(node->leftChild, key, name, comment);
        else
            node->rightChild = insert(node->rightChild, key, name, comment);
        return node;
    }


      // Task 03:
      //BST Traversal Preorder :
      //BST Traversal Inorder :
      //BST Traversal Postorder :

    void inOrder(Node* node) {
        if (node == NULL)
            return;
        inOrder(node->leftChild);
        cout << node->toString() << endl;
        inOrder(node->rightChild);
    }

    void preOrder(Node* node) {
        if (node == NULL)
            return;
        cout << node->toString() << endl;
        preOrder(node->leftChild);
        preOrder(node->rightChild);
    }

    void postOrder(Node* node) {
        if (node == NULL)
            return;
        postOrder(node->leftChild);
        postOrder(node->rightChild);
        cout << node->toString() << endl;
    }

    Node* findMin(Node* node) {
        while (node->leftChild != NULL)
            node = node->leftChild;
        return node;
    }


      // Task 04:
      //BST Deletion :
      
    Node* deleteNode(Node* node, int key) {
        if (node == NULL) {
            cout << "Key not found in the tree.\n";
            return NULL;
        }

        if (key < node->key) {
            node->leftChild = deleteNode(node->leftChild, key);
        } else if (key > node->key) {
            node->rightChild = deleteNode(node->rightChild, key);
        } else {
            if (node->leftChild == NULL) {
                Node* temp = node->rightChild;
                delete node;
                return temp;
            } else if (node->rightChild == NULL) {
                Node* temp = node->leftChild;
                delete node;
                return temp;
            }
            Node* temp = findMin(node->rightChild);
            node->key = temp->key;
            node->name = temp->name;
            node->comment = temp->comment;
            node->rightChild = deleteNode(node->rightChild, temp->key);
        }
        return node;
    }

    Node* search(Node* node, int key) {
        if (node == NULL || node->key == key)
            return node;

        if (key < node->key)
            return search(node->leftChild, key);
        return search(node->rightChild, key);
    }

    bool isBST(Node* node, int minKey, int maxKey) {
        if (node == NULL)
            return true;

        if (node->key <= minKey || node->key >= maxKey)
            return false;

        return isBST(node->leftChild, minKey, node->key) &&
               isBST(node->rightChild, node->key, maxKey);
    }

    int autoGrader() {
        string commentary;
        if (isBST(root, INT_MIN, INT_MAX)) {
            commentary = "Tree is properly structured as a BST.";
            cout << "The tree is a valid BST. Points: 10" << endl;
            cout << "Reason: " << commentary << endl;
            return 10;
        } else {
            commentary = "Tree violates BST properties.";
            cout << "The tree is NOT a valid BST. Points: 0" << endl;
            cout << "Reason: " << commentary << endl;
            return 0;
        }
    }

    void destroyTree(Node* node) {
        if (node == NULL)
            return;

        destroyTree(node->leftChild);
        destroyTree(node->rightChild);
        //cout << "Deleting node: " << node->toString() << endl;
        delete node;
    }

    void destroy() {
        destroyTree(root);
        root = NULL;
        cout << "All nodes have been deleted, and the tree is now empty.\n";
    }
};

int main() {
    BST tree;
    int choice, key;
    string name, comment;
     tree.root = tree.insert(tree.root, 15, "Rayyan", "Good marks");
    tree.root = tree.insert(tree.root, 10, "Taha", "Satisfactory");
    tree.root = tree.insert(tree.root, 20, "Aslam", "Above average");
    tree.root = tree.insert(tree.root, 8, "Noman", "Needs improvement");
    tree.root = tree.insert(tree.root, 12, "Ayesha", "Fair performance");
    tree.root = tree.insert(tree.root, 16, "Noreen", "Consistent");
    tree.root = tree.insert(tree.root, 25, "Ajwa", "Excellent");


menu:
    cout << "\n           AutoGrader Menu\n";
    cout << "                                  1. Insert New Student data\n";
    cout << "                                  2. Inorder Traversal\n";
    cout << "                                  3. Preorder Traversal\n";
    cout << "                                  4. Postorder Traversal\n";
    cout << "                                  5. Search Node\n";
    cout << "                                  6. Delete Student data\n";
    cout << "                                  7. Check tree is BST or not\n";
    cout << "                                  8. Destroy Entire Tree\n";
    cout << "                                  9. Exit\n";
    cout << "Enter your choice: ";
    cin >> choice;

    if (cin.fail() || choice < 1 || choice > 9) {
        cin.clear();
        cin.ignore(INT_MAX, '\n');
        cout << "Invalid input! Please enter a number between 1 and 9.\n";
        goto menu;
    }

    switch (choice) {
    case 1:
    input_marks:
        cout << "Enter Marks (0 to 100): ";
        cin >> key;
        if (cin.fail() || key < 0 || key > 100) {
            cin.clear();
            cin.ignore(INT_MAX, '\n');
            cout << "Invalid Marks! Enter a value between 0 and 100.\n";
            goto input_marks;
        }

        cin.ignore(); // Clear input buffer
        cout << "Enter Student name: ";
        getline(cin, name);
        cout << "Enter comments about Marks: ";
        getline(cin, comment);
        tree.root = tree.insert(tree.root, key, name, comment);
        break;

    case 2:
        cout << "Inorder Traversal:\n";
        tree.inOrder(tree.root);
        break;

    case 3:
        cout << "Preorder Traversal:\n";
        tree.preOrder(tree.root);
        break;

    case 4:
        cout << "Postorder Traversal:\n";
        tree.postOrder(tree.root);
        break;

    case 5:
        cout << "Enter key to search: ";
        cin >> key;
        if (cin.fail()) {
            cin.clear();
            cin.ignore(INT_MAX, '\n');
            cout << "Invalid input! Please enter a valid key.\n";
            goto menu;
        }
        {
            Node* result = tree.search(tree.root, key);
            if (result != NULL) {
                cout << "Node found: " << result->toString() << endl;
            } else {
                cout << "Node with key " << key << " not found.\n";
            }
        }
        break;

    case 6:
        cout << "Enter key to delete: ";
        cin >> key;
        if (cin.fail()) {
            cin.clear();
            cin.ignore(INT_MAX, '\n');
            cout << "Invalid input! Please enter a valid key.\n";
            goto menu;
        }
        tree.root = tree.deleteNode(tree.root, key);
        break;

    case 7:
        tree.autoGrader();
        break;

    case 8:
        tree.destroy();
        break;

    case 9:
        cout << "Exiting program.\n";
        return 0;
    }

    goto menu;
}

