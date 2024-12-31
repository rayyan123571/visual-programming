#include <iostream>
using namespace std;

struct ListNode {
    int value;
    ListNode* next;

    ListNode(int val) : value(val), next(NULL) {}
};

class LinkedList {
public:
    ListNode* head;

    LinkedList() : head(NULL) {}

    void reverse() {
        ListNode* prev = NULL;
        ListNode* current = head;
        ListNode* next = NULL;

        while (current != NULL) {
            next = current->next;
            current->next = prev;
            prev = current;
            current = next;
        }

        head = prev;
    }

    void insert(int value) {
        ListNode* newNode = new ListNode(value);
        if (head == NULL) {
            head = newNode;
        } else {
            ListNode* temp = head;
            while (temp->next != NULL) {
                temp = temp->next;
            }
            temp->next = newNode;
        }
    }

    void print() {
        ListNode* temp = head;
        while (temp != NULL) {
            cout << temp->value << " ";
            temp = temp->next;
        }
        cout << endl;
    }
};

int main() {
    LinkedList list;

    list.insert(1);
    list.insert(2);
    list.insert(3);
    list.insert(4);
    list.insert(5);

    cout << "Original List: ";
    list.print();

    list.reverse();

    cout << "Reversed List: ";
    list.print();

    
}

